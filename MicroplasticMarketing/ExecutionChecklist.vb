Namespace MicroplasticMarketing

    Public Class ExecutionChecklist

        Public Shared Sub PrintWeeklyChecklist()
            Console.WriteLine()
            Console.WriteLine("=" & New String("="c, 69))
            Console.WriteLine("  WEEKLY EXECUTION CHECKLIST — MICROPLASTIC CONSCIOUSNESS")
            Console.WriteLine("=" & New String("="c, 69))

            Dim weeks() As (String, String()) = {
                ("WEEK 1 — Pre-Launch & Awareness",
                 New String() {
                     "[ ] Finalize all Week 1 content (captions, visuals, video scripts)",
                     "[ ] Schedule Week 1 posts in Buffer (Instagram, Facebook, LinkedIn, Threads)",
                     "[ ] Upload TikTok and YouTube videos manually",
                     "[ ] Set up n8n workflow: Google Sheet → Buffer auto-scheduling",
                     "[ ] Send first wave of podcast outreach emails (5-10 targets)",
                     "[ ] Create Instagram Story sequence for Day 1 launch",
                     "[ ] Prepare giveaway graphics for Day 7",
                     "[ ] Set up link-in-bio page (Linktree or similar)",
                     "[ ] Create campaign hashtag: #MicroplasticConsciousness",
                     "[ ] Brief any collaborators or launch team"
                 }),
                ("WEEK 2 — Science Deep Dive",
                 New String() {
                     "[ ] Record and edit YouTube video (Microplastics & Hormones)",
                     "[ ] Design 5-slide science carousel for Instagram",
                     "[ ] Write and post LinkedIn research roundup article",
                     "[ ] Post chapter preview carousel (Day 14)",
                     "[ ] Follow up on Week 1 podcast pitches",
                     "[ ] Send media/press outreach (3-5 journalists or editors)",
                     "[ ] Monitor and reply to all Week 1 comments",
                     "[ ] Track engagement: saves, shares, follows gained",
                     "[ ] Update n8n/Buffer queue with Week 3 content",
                     "[ ] Collect early reader reviews and screenshots for Week 3"
                 }),
                ("WEEK 3 — Community & Story",
                 New String() {
                     "[ ] Record author origin story YouTube video",
                     "[ ] Schedule Facebook Live (Q&A — Day 19)",
                     "[ ] Prepare Q&A talking points and research citations",
                     "[ ] Launch UGC campaign on TikTok (Day 17)",
                     "[ ] Compile reader testimonials for social proof carousel",
                     "[ ] Send partner organization outreach (3-5 orgs)",
                     "[ ] Reply to all Threads comments from Days 13-14",
                     "[ ] Feature top community comments / reposts",
                     "[ ] Mid-campaign analytics review (reach, saves, link clicks)",
                     "[ ] Adjust Week 4 content based on what performed best"
                 }),
                ("WEEK 4 — Action & Close",
                 New String() {
                     "[ ] Record '10 Ways to Reduce Microplastic Exposure' YouTube video",
                     "[ ] Design action-step carousel for Instagram",
                     "[ ] Write urgency post for Day 28 (last 72 hrs of launch offer)",
                     "[ ] Activate any limited-time discount or signed copy offer",
                     "[ ] Follow up with all podcast/media contacts from Weeks 1-2",
                     "[ ] Send influencer/creator outreach (5-10 targets)",
                     "[ ] Request reviews from early readers via email",
                     "[ ] Cross-post top performing content to underperforming platforms",
                     "[ ] Prepare Day 29-30 finale content",
                     "[ ] Draft 30-day results report (reach, followers gained, sales)"
                 }),
                ("WEEK 5 — Finale & Evergreen",
                 New String() {
                     "[ ] Record and post Day 30 YouTube finale video",
                     "[ ] Post community thank-you reel on Instagram",
                     "[ ] Send post-campaign email to all early readers requesting reviews",
                     "[ ] Pin top-performing post on each platform",
                     "[ ] Archive best content for evergreen repurposing",
                     "[ ] Analyze full 30-day campaign performance",
                     "[ ] Plan Month 2 content strategy based on data",
                     "[ ] Identify top 3 performing platforms — double down",
                     "[ ] Schedule Month 2 podcast interview appearances",
                     "[ ] Celebrate — you ran a full 30-day book launch campaign."
                 })
            }

            For Each w In weeks
                Console.WriteLine()
                Console.WriteLine($"  {w.Item1}")
                Console.WriteLine("  " & New String("─"c, 67))
                For Each task In w.Item2
                    Console.WriteLine($"  {task}")
                Next
            Next
        End Sub

        Public Shared Sub PrintPlatformSystem()
            Console.WriteLine()
            Console.WriteLine("=" & New String("="c, 69))
            Console.WriteLine("  PLATFORM PUBLISHING SYSTEM")
            Console.WriteLine("  n8n (Automation) + Buffer (Scheduling)")
            Console.WriteLine("=" & New String("="c, 69))

            Dim platforms() As (String, String, String, String, String) = {
                ("INSTAGRAM",
                 "4-5x/week",
                 "Reels (primary), Carousels, Stories, Posts",
                 "Best times: Tue/Thu/Sat 9-11am or 6-8pm local",
                 "Buffer: Schedule all feed posts. n8n: Pull from content sheet, auto-fill Buffer queue."),
                ("TIKTOK",
                 "Daily or 5x/week",
                 "Short-form video (15-60 sec), Duets, Replies",
                 "Best times: 7-9am, 12-3pm, 7-11pm",
                 "Post manually or via TikTok native scheduler. n8n can trigger reminders."),
                ("YOUTUBE",
                 "1-2x/week",
                 "Long-form (8-15 min), Shorts, Community Posts",
                 "Best days: Thu/Fri/Sat, upload 24hr before publish",
                 "Upload manually. Use n8n to track upload checklist and notify Buffer for cross-promo posts."),
                ("FACEBOOK",
                 "3-4x/week",
                 "Posts, Videos, Live, Shares",
                 "Best times: Wed-Sun, 1-4pm",
                 "Buffer: Schedule all posts. Link Facebook Page and Group. n8n: auto-copy Instagram captions."),
                ("LINKEDIN",
                 "2-3x/week",
                 "Posts, Articles, Carousels, Native Video",
                 "Best times: Tue-Thu 8-10am or 12pm",
                 "Buffer: Schedule posts. Write LinkedIn-native content (more professional tone)."),
                ("THREADS",
                 "Daily (lightweight)",
                 "Short posts, Threads, Replies",
                 "Post in real-time or 1-2x/day",
                 "Manual posting or Buffer (if supported). n8n: repurpose top Instagram captions as Threads.")
            }

            For Each p In platforms
                Console.WriteLine()
                Console.WriteLine($"  {p.Item1}")
                Console.WriteLine($"  Frequency : {p.Item2}")
                Console.WriteLine($"  Formats   : {p.Item3}")
                Console.WriteLine($"  Timing    : {p.Item4}")
                Console.WriteLine($"  Workflow  : {p.Item5}")
                Console.WriteLine("  " & New String("─"c, 67))
            Next
        End Sub

    End Class

End Namespace
