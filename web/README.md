# Hero Animation — Integration Guide

Animated wind + bird effects for the Carlos Olivencia Tax Services hero banner.

## Files

| File | Purpose |
|------|---------|
| `hero-animation.html` | Self-contained demo (open in any browser to preview) |
| `hero-animation.css`  | All CSS `@keyframes` — wind sway, wisteria, petals, waterfall, birds |
| `hero-animation.js`   | Canvas wind particles · SVG bird flight along Bézier paths · falling petals |

## What Gets Animated

| Element | Effect |
|---------|--------|
| Background image | Subtle brightness/saturation breathe (`hero-breathe`) |
| Wisteria clusters | Gentle side-to-side sway (`wisteria-sway`) |
| Foreground leaves | Slow rustle / scale pulse (`leaf-rustle`) |
| Wind streaks | CSS `<div>` elements drifting left→right across the hero |
| Wind particles | Canvas-drawn translucent streaks; 80-particle pool via `requestAnimationFrame` |
| Falling petals | Pink / cream / wisteria-blue petals spawned from the tree canopy |
| Waterfall | Vertical shimmer pulse overlay on the right-side waterfall (`waterfall-flow`) |
| Birds | SVG macaw (blue/gold), parakeet (green/yellow), swift (brown), small heron — each flies a unique randomised cubic Bézier arc; wings flap via CSS `wing-flap-top` / `wing-flap-bot` |
| Cartoon avatar | Subtle vertical bob in the breeze (`avatar-bob`) |

## How to Add to an Existing Site

### 1 — Add the CSS

```html
<link rel="stylesheet" href="hero-animation.css" />
```

Or copy the contents of `hero-animation.css` into your existing stylesheet.

### 2 — Mark up the hero section

Your hero wrapper **must** have `id="hero-section"` and `position: relative` (or
`absolute` / `fixed`). Add the canvas and the waterfall shimmer div inside it:

```html
<section id="hero-section">
  <!-- your background image element / div -->

  <!-- Wind particle canvas — populated by hero-animation.js -->
  <canvas id="wind-canvas" aria-hidden="true"></canvas>

  <!-- Waterfall shimmer overlay -->
  <div class="waterfall-shimmer" aria-hidden="true"></div>

  <!-- rest of your hero content -->
</section>
```

### 3 — Load the JS

```html
<script src="hero-animation.js" defer></script>
```

That's it. The script auto-detects `#hero-section`, resizes the canvas on window
resize, and pauses canvas rendering when the browser tab is hidden (battery saver).

## Customisation

### Change bird colours
Edit the `BIRD_SPECS` array near the top of `hero-animation.js`:

```js
const BIRD_SPECS = [
  { color1: "#1a6eb5", color2: "#f5c842", color3: "#2ca04a", size: 52, name: "macaw"    },
  { color1: "#3ab54a", color2: "#f9e84e", color3: "#a0d86e", size: 42, name: "parakeet" },
  // ...
];
```

### Wind intensity
Adjust `MAX_PARTICLES` (default `80`) and the `speed` range in `spawnParticle()`.

### Animation speed
- Wisteria sway period: `4.5s` in `.wisteria-overlay` rule in the CSS.
- Bird crossing time: `rand(7, 18)` seconds in `createBirdFlight()`.
- Petal fall time: `rand(4, 9)` seconds in `spawnPetal()`.

### Disable a specific effect
Comment out the corresponding `init*()` call in the `boot()` function at the
bottom of `hero-animation.js`:

```js
function boot() {
  // initWindCanvas(hero);   ← disable canvas particles
  // initWindStreaks(hero);  ← disable CSS streaks
  // initPetals(hero);       ← disable falling petals
  // initBirds(hero);        ← disable bird flight
}
```
