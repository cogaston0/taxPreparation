/**
 * hero-animation.js
 * Wind particles + animated bird flight for the Carlos Olivencia Tax hero banner.
 *
 * Usage:
 *   <script src="hero-animation.js" defer></script>
 *
 * The script looks for:
 *   #hero-section  — the hero wrapper element
 *   #wind-canvas   — a <canvas> that spans the hero
 *   #bird-layer    — an absolutely-positioned container for SVG birds
 *
 * All spawning and RAF loop is self-contained; no dependencies required.
 */
(function () {
  "use strict";

  /* ── Helpers ─────────────────────────────────────────────────── */
  const rand  = (min, max) => Math.random() * (max - min) + min;
  const randI = (min, max) => Math.floor(rand(min, max + 1));
  const clamp = (v, lo, hi) => Math.max(lo, Math.min(hi, v));

  /* ── Bézier helpers for bird flight curves ─────────────────── */
  function cubicBezier(t, p0, p1, p2, p3) {
    const u = 1 - t;
    return u * u * u * p0 + 3 * u * u * t * p1 + 3 * u * t * t * p2 + t * t * t * p3;
  }

  /* ─────────────────────────────────────────────────────────────── */
  /* 1.  WIND-PARTICLE CANVAS                                         */
  /* ─────────────────────────────────────────────────────────────── */
  function initWindCanvas(hero) {
    const canvas = document.getElementById("wind-canvas");
    if (!canvas) return;

    const ctx    = canvas.getContext("2d");
    const W      = () => canvas.width;
    const H      = () => canvas.height;

    /* Resize to match hero */
    function resize() {
      canvas.width  = hero.offsetWidth;
      canvas.height = hero.offsetHeight;
    }
    resize();
    window.addEventListener("resize", resize);

    /* Particle pool */
    const MAX_PARTICLES = 80;
    const particles = [];

    function spawnParticle() {
      // Wind blows left → right with slight downward drift
      const y = rand(0, H() * 0.75);          // upper ¾ of hero
      const speed  = rand(60, 200);            // px/s
      const length = rand(20, 120);
      const alpha  = rand(0.08, 0.22);
      particles.push({
        x:     -length,
        y:     y,
        vy:    rand(-8, 18),                   // slight vertical drift
        speed: speed,
        len:   length,
        alpha: alpha,
        life:  0,
        maxLife: (W() + length) / speed,       // seconds until off-screen
      });
    }

    /* Pre-populate */
    for (let i = 0; i < 30; i++) {
      spawnParticle();
      // Scatter initial x so they don't all start left
      particles[i].x = rand(-length, W());
    }

    let last = null;
    function tick(now) {
      if (!last) last = now;
      const dt = Math.min((now - last) / 1000, 0.05); // seconds, capped
      last = now;

      ctx.clearRect(0, 0, W(), H());

      /* Spawn new particles to keep pool full */
      while (particles.length < MAX_PARTICLES) spawnParticle();

      /* Update & draw */
      for (let i = particles.length - 1; i >= 0; i--) {
        const p = particles[i];
        p.x    += p.speed * dt;
        p.y    += p.vy   * dt;
        p.life += dt;

        /* Fade in/out */
        let a = p.alpha;
        const fraction = p.life / p.maxLife;
        if (fraction < 0.1) a *= fraction / 0.1;
        if (fraction > 0.8) a *= (1 - fraction) / 0.2;

        ctx.save();
        ctx.globalAlpha = a;
        ctx.strokeStyle = "rgba(255,255,255,1)";
        ctx.lineWidth   = rand(0.4, 1.2);
        ctx.beginPath();
        ctx.moveTo(p.x, p.y);
        ctx.lineTo(p.x - p.len, p.y - p.vy * 0.3);
        ctx.stroke();
        ctx.restore();

        /* Remove off-screen particles */
        if (p.x > W() + p.len || p.life > p.maxLife + 0.5) {
          particles.splice(i, 1);
        }
      }

      requestAnimationFrame(tick);
    }
    requestAnimationFrame(tick);
  }

  /* ─────────────────────────────────────────────────────────────── */
  /* 2.  FALLING PETALS                                               */
  /* ─────────────────────────────────────────────────────────────── */
  function initPetals(hero) {
    const COLORS = [
      "#f9d9e7", // pink blossom
      "#ffe8c0", // cream
      "#d4e8ff", // pale blue wisteria
      "#c8f5c8", // pale green leaf
      "#f7c6d4", // blush
    ];
    const MAX = 18;
    let count = 0;

    function spawnPetal() {
      if (count >= MAX) return;
      const el = document.createElement("div");
      el.className = "petal";

      const size   = rand(5, 14);
      const startX = rand(0, hero.offsetWidth * 0.7);  // left-biased (wisteria side)
      const fall   = rand(hero.offsetHeight * 0.4, hero.offsetHeight * 0.9);
      const drift  = rand(-80, 120);
      const spin   = rand(-360, 360) + "deg";
      const dur    = rand(4, 9);
      const color  = COLORS[randI(0, COLORS.length - 1)];
      const delay  = rand(0, 4);

      Object.assign(el.style, {
        width:      size + "px",
        height:     size * 0.6 + "px",
        top:        rand(2, 25) + "%",
        left:       startX + "px",
        background: color,
        "--fall-distance": fall + "px",
        "--drift":         drift + "px",
        "--spin":          spin,
        animationDuration: dur + "s",
        animationDelay:    delay + "s",
      });

      el.addEventListener("animationend", () => {
        el.remove();
        count--;
        // Respawn after a short pause
        setTimeout(spawnPetal, rand(200, 1500));
      });

      hero.appendChild(el);
      count++;
    }

    for (let i = 0; i < MAX; i++) spawnPetal();
  }

  /* ─────────────────────────────────────────────────────────────── */
  /* 3.  BIRDS                                                        */
  /* ─────────────────────────────────────────────────────────────── */

  /**
   * Build a simple two-wing bird SVG.
   * color1 = body/head, color2 = wing accent, color3 = breast
   */
  function makeBirdSVG(color1, color2, color3, size) {
    const s = size;
    // Simple stylised bird: body oval + two arched wings
    return `
<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 70"
     width="${s}" height="${s * 0.7}" style="overflow:visible">
  <!-- Body -->
  <ellipse cx="50" cy="42" rx="22" ry="13" fill="${color1}"/>
  <!-- Head -->
  <circle  cx="72" cy="34" r="10" fill="${color1}"/>
  <!-- Beak -->
  <path d="M81 32 L93 29 L81 36 Z" fill="${color2}"/>
  <!-- Eye -->
  <circle cx="75" cy="31" r="2.5" fill="white"/>
  <circle cx="76" cy="31" r="1.4" fill="#111"/>
  <!-- Tail feathers -->
  <path d="M28 45 Q10 55 5 65 Q18 55 28 50 Z" fill="${color2}" class="wing-bottom"/>
  <!-- Upper wing -->
  <g class="wing-top">
    <path d="M42 35 Q48 12 70 20 Q55 18 42 35 Z" fill="${color2}"/>
    <path d="M42 35 Q45 18 62 22 Q52 20 42 35 Z" fill="${color3}" opacity="0.7"/>
  </g>
  <!-- Lower wing (counter-flap) -->
  <g class="wing-bottom">
    <path d="M38 48 Q35 62 55 60 Q45 58 38 48 Z" fill="${color2}" opacity="0.8"/>
  </g>
</svg>`.trim();
  }

  /**
   * Bird species definitions matching the painting:
   * – Macaw (large blue/gold)
   * – Parakeet (yellow-green)
   * – Small swift / sparrow
   */
  const BIRD_SPECS = [
    { color1: "#1a6eb5", color2: "#f5c842", color3: "#2ca04a", size: 52, name: "macaw"    },
    { color1: "#3ab54a", color2: "#f9e84e", color3: "#a0d86e", size: 42, name: "parakeet" },
    { color1: "#6b4f2e", color2: "#c8a060", color3: "#ecdab4", size: 28, name: "swift"    },
    { color1: "#1a4a8a", color2: "#0e8c9c", color3: "#b8dde8", size: 38, name: "heron"   },
  ];

  /** A live bird object flying along a cubic Bézier path */
  function createBirdFlight(hero, spec) {
    const W = hero.offsetWidth;
    const H = hero.offsetHeight;

    // RTL or LTR
    const ltr   = Math.random() < 0.65;  // 65 % fly left→right (prevailing wind)
    const startX = ltr ? -spec.size : W + spec.size;
    const endX   = ltr ? W + spec.size  : -spec.size;

    // Vertical band: birds stay in upper 55 % of the hero
    const band  = H * 0.55;
    const y0    = rand(H * 0.03, band);
    const y1    = rand(H * 0.03, band);
    const y2    = rand(H * 0.03, band);
    const y3    = rand(H * 0.03, band);

    // Control points for horizontal axis
    const x1 = startX + (endX - startX) * rand(0.2, 0.45);
    const x2 = startX + (endX - startX) * rand(0.55, 0.8);

    const duration = rand(7, 18);   // seconds to cross the viewport
    const flapSpeed = rand(0.28, 0.50) + "s";

    // Create wrapper
    const wrapper = document.createElement("div");
    wrapper.style.cssText = "position:absolute;pointer-events:none;z-index:4;top:0;left:0;";
    wrapper.innerHTML = makeBirdSVG(spec.color1, spec.color2, spec.color3, spec.size);

    const svg = wrapper.querySelector("svg");

    // Apply wing-flap speed
    wrapper.querySelectorAll(".wing-top, .wing-bottom").forEach(el => {
      el.style.setProperty("--flap-speed", flapSpeed);
    });

    // Flip SVG horizontally for RTL birds
    if (!ltr) svg.style.transform = "scaleX(-1)";

    hero.appendChild(wrapper);

    let start = null;
    function animate(ts) {
      if (!start) start = ts;
      const t = clamp((ts - start) / (duration * 1000), 0, 1);

      const bx = cubicBezier(t, startX, x1, x2, endX);
      const by = cubicBezier(t, y0, y1, y2, y3);

      // Gentle bank: rotate based on vertical velocity direction
      const prev_by = cubicBezier(Math.max(t - 0.005, 0), y0, y1, y2, y3);
      const bankDeg = clamp((by - prev_by) * 2, -18, 18);

      wrapper.style.transform = `translate(${bx}px, ${by}px) rotate(${bankDeg}deg)`;

      if (t < 1) {
        requestAnimationFrame(animate);
      } else {
        wrapper.remove();
        // Schedule next bird after a random pause
        const pause = rand(1500, 5000);
        setTimeout(() => createBirdFlight(hero, spec), pause);
      }
    }
    requestAnimationFrame(animate);
  }

  function initBirds(hero) {
    // Stagger initial spawns so they don't all appear simultaneously
    BIRD_SPECS.forEach((spec, i) => {
      setTimeout(() => createBirdFlight(hero, spec), i * rand(800, 2400));
    });
    // Extra pair of smaller birds
    setTimeout(() => createBirdFlight(hero, BIRD_SPECS[2]), rand(4000, 8000));
    setTimeout(() => createBirdFlight(hero, BIRD_SPECS[0]), rand(3000, 6000));
  }

  /* ─────────────────────────────────────────────────────────────── */
  /* 4.  WIND-STREAK CSS ELEMENTS                                     */
  /* ─────────────────────────────────────────────────────────────── */
  function spawnWindStreak(hero) {
    const el = document.createElement("div");
    el.className = "wind-streak";

    const y      = rand(5, 75);          // % height
    const width  = rand(60, 240);
    const travel = (hero.offsetWidth - rand(0, 200)) + "px";
    const dur    = rand(0.8, 2.2);
    const delay  = rand(0, 3);

    Object.assign(el.style, {
      top:               y + "%",
      left:              rand(-60, 0) + "px",
      width:             width + "px",
      "--streak-travel": travel,
      animationDuration: dur + "s",
      animationDelay:    delay + "s",
    });

    el.addEventListener("animationend", () => {
      el.remove();
      setTimeout(() => spawnWindStreak(hero), rand(200, 2000));
    });

    hero.appendChild(el);
  }

  function initWindStreaks(hero) {
    for (let i = 0; i < 14; i++) spawnWindStreak(hero);
  }

  /* ─────────────────────────────────────────────────────────────── */
  /* 5.  BOOTSTRAP                                                    */
  /* ─────────────────────────────────────────────────────────────── */
  function boot() {
    const hero = document.getElementById("hero-section");
    if (!hero) {
      console.warn("[hero-animation] #hero-section not found — animations skipped.");
      return;
    }

    // Ensure hero is a positioning context
    const pos = getComputedStyle(hero).position;
    if (pos === "static") hero.style.position = "relative";

    initWindCanvas(hero);
    initWindStreaks(hero);
    initPetals(hero);
    initBirds(hero);

    // Pause heavy animations when tab is hidden (battery saver)
    document.addEventListener("visibilitychange", () => {
      const canvas = document.getElementById("wind-canvas");
      if (canvas) canvas.style.display = document.hidden ? "none" : "";
    });
  }

  if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", boot);
  } else {
    boot();
  }
})();
