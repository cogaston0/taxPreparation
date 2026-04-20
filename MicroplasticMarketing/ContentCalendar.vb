Namespace MicroplasticMarketing

    Public Class ContentCalendar

        Private Shared ReadOnly StartDate As DateTime = New DateTime(2026, 5, 1)

        ' ----------------------------------------------------------------
        ' WEEK 1 — AWARENESS: Introducing the Problem
        ' ----------------------------------------------------------------
        Public Shared Function BuildWeek1() As WeekPlan
            Dim week As New WeekPlan With {
                .WeekNumber = 1,
                .Theme = "AWARENESS — Introducing the Problem",
                .Goal = "Stop the scroll. Make people realize microplastics are already inside them."
            }

            ' Day 1 — Instagram Reel
            week.Posts.Add(New SocialPost With {
                .Day = 1,
                .PostDate = StartDate,
                .Platform = Platform.Instagram,
                .ContentType = ContentType.Reel,
                .Pillar = ContentPillar.Awareness,
                .Hook = "You've swallowed a credit card worth of plastic this week.",
                .Caption = "New research confirms microplastics in human brain tissue. " &
                           "This is not a future problem — it's happening right now, inside your body. " &
                           "Microplastic Consciousness is the book that breaks it all down. Link in bio.",
                .CallToAction = "Save this. Share it. The conversation starts here.",
                .VisualNote = "Close-up of plastic bottle + human brain scan overlay. Bold stat text on screen.",
                .Duration = "30-45 sec",
                .Hashtags = New List(Of String) From {"#microplastics", "#healthawareness", "#MicroplasticConsciousness", "#toxinfree", "#booktok"}
            })

            ' Day 1 — TikTok
            week.Posts.Add(New SocialPost With {
                .Day = 1,
                .PostDate = StartDate,
                .Platform = Platform.TikTok,
                .ContentType = ContentType.Short,
                .Pillar = ContentPillar.Awareness,
                .Hook = "Scientists found microplastics in the human brain. Here's what that means for YOU.",
                .Caption = "The research is in and it changes everything 🧠 #microplastics #health #consciousness #booktok #science",
                .CallToAction = "Follow for more. This is week 1 of 30.",
                .VisualNote = "Fast cuts — stat on screen, researcher footage, book cover reveal at end.",
                .Duration = "30-60 sec",
                .Hashtags = New List(Of String) From {"#microplastics", "#health", "#consciousness", "#booktok", "#science"}
            })

            ' Day 2 — LinkedIn
            week.Posts.Add(New SocialPost With {
                .Day = 2,
                .PostDate = StartDate.AddDays(1),
                .Platform = Platform.LinkedIn,
                .ContentType = ContentType.Post,
                .Pillar = ContentPillar.Science,
                .Hook = "Microplastics are now confirmed in human brain tissue. This is a professional health conversation.",
                .Caption = "Peer-reviewed research published in 2024 detected microplastic particles in human brain tissue samples. " &
                           "The concentration was higher in brain samples from individuals who died with dementia. " &
                           "As professionals, parents, and leaders — we cannot ignore the emerging science on environmental " &
                           "contamination and neurological health. " &
                           "My book Microplastic Consciousness synthesizes this research and offers a framework for informed action.",
                .CallToAction = "What's your organization doing about environmental health? Comment below.",
                .VisualNote = "Clean infographic: brain diagram with microplastic entry points.",
                .Hashtags = New List(Of String) From {"#environmentalhealth", "#publichealth", "#sustainability", "#leadership", "#microplastics"}
            })

            ' Day 2 — Threads
            week.Posts.Add(New SocialPost With {
                .Day = 2,
                .PostDate = StartDate.AddDays(1),
                .Platform = Platform.Threads,
                .ContentType = ContentType.Thread,
                .Pillar = ContentPillar.Awareness,
                .Hook = "Thread: 5 places microplastics are hiding in your daily routine (and what to do about it). 1/6",
                .Caption = "1/ Your tap water. 2/ Your sea salt. 3/ Your takeout containers. 4/ Your clothing fibers. 5/ Your indoor air. " &
                           "None of this is meant to terrify you. It's meant to wake you up. Full breakdown in Microplastic Consciousness.",
                .CallToAction = "Which one surprised you most? Reply below.",
                .VisualNote = "Text-only thread — conversational tone.",
                .Hashtags = New List(Of String) From {"#microplastics", "#awareness", "#MicroplasticConsciousness"}
            })

            ' Day 3 — YouTube
            week.Posts.Add(New SocialPost With {
                .Day = 3,
                .PostDate = StartDate.AddDays(2),
                .Platform = Platform.YouTube,
                .ContentType = ContentType.Video,
                .Pillar = ContentPillar.Science,
                .Hook = "The Science of Microplastics: What's Really Inside Your Body",
                .Caption = "In this video I break down the peer-reviewed science of microplastic contamination — " &
                           "where it comes from, how it enters the body, and what the latest research says about " &
                           "brain tissue, hormones, and long-term health. " &
                           "This is the foundation behind my book Microplastic Consciousness. " &
                           "Sources linked in description. Subscribe for weekly deep dives.",
                .CallToAction = "Subscribe and hit the bell. New video every week.",
                .VisualNote = "Talking-head format + animated explainer graphics. Professional but accessible.",
                .Duration = "8-12 min",
                .Hashtags = New List(Of String) From {"#microplastics", "#science", "#health", "#environment", "#MicroplasticConsciousness"}
            })

            ' Day 3 — Facebook
            week.Posts.Add(New SocialPost With {
                .Day = 3,
                .PostDate = StartDate.AddDays(2),
                .Platform = Platform.Facebook,
                .ContentType = ContentType.Post,
                .Pillar = ContentPillar.Awareness,
                .Hook = "Did you know you're eating roughly 5 grams of plastic every week?",
                .Caption = "That's the weight of a credit card — every week — entering your body through food, water, and air. " &
                           "I wrote Microplastic Consciousness because I needed people to understand what the science actually says, " &
                           "in a way that empowers action rather than panic. " &
                           "Share this post if you think more people need to know.",
                .CallToAction = "Share with one person who needs to read this.",
                .VisualNote = "Credit card on a plate — striking, visual metaphor image.",
                .Hashtags = New List(Of String) From {"#microplastics", "#health", "#plasticpollution", "#MicroplasticConsciousness"}
            })

            ' Day 4 — Instagram Carousel
            week.Posts.Add(New SocialPost With {
                .Day = 4,
                .PostDate = StartDate.AddDays(3),
                .Platform = Platform.Instagram,
                .ContentType = ContentType.Carousel,
                .Pillar = ContentPillar.Science,
                .Hook = "5 facts about microplastics that will change how you live. Swipe →",
                .Caption = "The science is clear. The question is: what do we do with it? " &
                           "These 5 facts are pulled directly from Microplastic Consciousness. " &
                           "Save this post and share it with someone who needs to see this.",
                .CallToAction = "Save this. Then grab the book.",
                .VisualNote = "Slide 1: Title. Slides 2-6: One fact each with bold stat + visual. Slide 7: Book CTA.",
                .Hashtags = New List(Of String) From {"#microplastics", "#healthfacts", "#science", "#MicroplasticConsciousness", "#environmentalhealth"}
            })

            ' Day 5 — TikTok Challenge
            week.Posts.Add(New SocialPost With {
                .Day = 5,
                .PostDate = StartDate.AddDays(4),
                .Platform = Platform.TikTok,
                .ContentType = ContentType.Short,
                .Pillar = ContentPillar.Community,
                .Hook = "Name one plastic item you're giving up this month. Go.",
                .Caption = "Starting a 30-day plastic awareness challenge. Join me 👇 #microplastics #plasticfree #challenge #wellness #MicroplasticConsciousness",
                .CallToAction = "Comment your pledge. I'll repost the best ones.",
                .VisualNote = "Author on camera — direct address, casual and energetic.",
                .Duration = "15-30 sec",
                .Hashtags = New List(Of String) From {"#microplastics", "#plasticfree", "#challenge", "#wellness", "#MicroplasticConsciousness"}
            })

            ' Day 6 — LinkedIn Article
            week.Posts.Add(New SocialPost With {
                .Day = 6,
                .PostDate = StartDate.AddDays(5),
                .Platform = Platform.LinkedIn,
                .ContentType = ContentType.Post,
                .Pillar = ContentPillar.PersonalStory,
                .Hook = "Why I spent years researching what plastic does to the human body — and what I found.",
                .Caption = "When I began writing Microplastic Consciousness, I wasn't sure the world was ready for this conversation. " &
                           "Now, with microplastics confirmed in brain tissue, bloodstreams, and fetuses — I know it can't wait. " &
                           "Here's the personal story behind the research, and why I believe awareness is the first form of healing. " &
                           "Full post at the link.",
                .CallToAction = "Follow for updates. The full story is in the book.",
                .VisualNote = "Author headshot + book cover. Clean, professional.",
                .Hashtags = New List(Of String) From {"#authorsoflinkedin", "#environmentalhealth", "#microplastics", "#booklaunch", "#sustainability"}
            })

            ' Day 7 — All Platforms: Weekly Recap / Story
            week.Posts.Add(New SocialPost With {
                .Day = 7,
                .PostDate = StartDate.AddDays(6),
                .Platform = Platform.Instagram,
                .ContentType = ContentType.Story,
                .Pillar = ContentPillar.BookPromotion,
                .Hook = "Week 1 recap + a special reader offer.",
                .Caption = "We launched. The response has been incredible. " &
                           "To celebrate week 1, I'm giving away 3 signed copies. " &
                           "Tap the link to enter and grab your copy of Microplastic Consciousness.",
                .CallToAction = "Swipe up / Link sticker: Enter giveaway or buy the book.",
                .VisualNote = "Story series: Stats from the week + book cover + giveaway graphic.",
                .Hashtags = New List(Of String) From {"#giveaway", "#MicroplasticConsciousness", "#booklaunch"}
            })

            Return week
        End Function

        ' ----------------------------------------------------------------
        ' WEEK 2 — SCIENCE DEEP DIVE
        ' ----------------------------------------------------------------
        Public Shared Function BuildWeek2() As WeekPlan
            Dim week As New WeekPlan With {
                .WeekNumber = 2,
                .Theme = "SCIENCE DEEP DIVE — The Research They're Not Talking About",
                .Goal = "Establish credibility. Convert curious followers into engaged readers."
            }

            Dim posts() As (Integer, Platform, ContentType, ContentPillar, String, String) = {
                (8,  Platform.YouTube,   ContentType.Video,    ContentPillar.Science,       "Microplastics & Hormones: What the Research Actually Says",          "Deep dive into endocrine disruption research. 10-15 min."),
                (9,  Platform.Instagram, ContentType.Reel,     ContentPillar.Science,       "This is what 5g of plastic looks like inside your body every week.", "Animated infographic reel."),
                (10, Platform.TikTok,    ContentType.Short,    ContentPillar.Science,       "The study that changed everything about microplastics and the brain.", "Reference 2024 brain tissue study."),
                (11, Platform.LinkedIn,  ContentType.Post,     ContentPillar.Science,       "3 peer-reviewed studies every professional should read about microplastics.", "Research roundup post."),
                (12, Platform.Facebook,  ContentType.Post,     ContentPillar.ActionSteps,   "Here's what cutting plastic for 30 days does to your body.",           "Data-backed action post."),
                (13, Platform.Threads,   ContentType.Thread,   ContentPillar.Science,       "Thread: The microplastic-hormone connection explained in plain English. 1/7", "Accessible science thread."),
                (14, Platform.Instagram, ContentType.Carousel, ContentPillar.BookPromotion, "Inside Microplastic Consciousness: Chapter 1 preview. Swipe to read.", "Chapter excerpt carousel.")
            }

            For Each p In posts
                week.Posts.Add(New SocialPost With {
                    .Day = p.Item1,
                    .PostDate = StartDate.AddDays(p.Item1 - 1),
                    .Platform = p.Item2,
                    .ContentType = p.Item3,
                    .Pillar = p.Item4,
                    .Hook = p.Item5,
                    .Caption = p.Item6,
                    .CallToAction = "Follow for daily content. Book link in bio.",
                    .Hashtags = New List(Of String) From {"#microplastics", "#science", "#MicroplasticConsciousness", "#health"}
                })
            Next

            Return week
        End Function

        ' ----------------------------------------------------------------
        ' WEEK 3 — PERSONAL STORY & COMMUNITY
        ' ----------------------------------------------------------------
        Public Shared Function BuildWeek3() As WeekPlan
            Dim week As New WeekPlan With {
                .WeekNumber = 3,
                .Theme = "PERSONAL STORY & COMMUNITY — Why This Matters to Me, and to You",
                .Goal = "Build emotional connection. Grow community. Drive word-of-mouth."
            }

            Dim posts() As (Integer, Platform, ContentType, ContentPillar, String, String) = {
                (15, Platform.YouTube,   ContentType.Video,    ContentPillar.PersonalStory,  "My Story: Why I Wrote Microplastic Consciousness",                   "Author origin story. 8-12 min."),
                (16, Platform.Instagram, ContentType.Reel,     ContentPillar.PersonalStory,  "The moment I realized plastic was changing me from the inside out.", "Personal, vulnerable reel."),
                (17, Platform.TikTok,    ContentType.Short,    ContentPillar.Community,      "Share your plastic-free swap. I'll feature the best ones.",          "Community UGC prompt."),
                (18, Platform.LinkedIn,  ContentType.Post,     ContentPillar.PersonalStory,  "What writing this book taught me about courage and science.",         "Thought leadership post."),
                (19, Platform.Facebook,  ContentType.LiveSession, ContentPillar.Community,   "LIVE: Q&A — Ask me anything about microplastics",                    "30-min Facebook Live."),
                (20, Platform.Threads,   ContentType.Thread,   ContentPillar.Community,      "What's your biggest question about microplastics? I'll answer every single one. 🧵", "Engagement thread."),
                (21, Platform.Instagram, ContentType.Carousel, ContentPillar.PersonalStory,  "Reader reactions: What people are saying about Microplastic Consciousness. Swipe →", "Social proof carousel.")
            }

            For Each p In posts
                week.Posts.Add(New SocialPost With {
                    .Day = p.Item1,
                    .PostDate = StartDate.AddDays(p.Item1 - 1),
                    .Platform = p.Item2,
                    .ContentType = p.Item3,
                    .Pillar = p.Item4,
                    .Hook = p.Item5,
                    .Caption = p.Item6,
                    .CallToAction = "Link in bio. Share this with someone who needs it.",
                    .Hashtags = New List(Of String) From {"#MicroplasticConsciousness", "#community", "#health", "#microplastics"}
                })
            Next

            Return week
        End Function

        ' ----------------------------------------------------------------
        ' WEEK 4 — ACTION STEPS & BOOK CLOSE
        ' ----------------------------------------------------------------
        Public Shared Function BuildWeek4() As WeekPlan
            Dim week As New WeekPlan With {
                .WeekNumber = 4,
                .Theme = "ACTION & CLOSE — What You Can Do. Why The Book Is the Next Step.",
                .Goal = "Convert audience into buyers. Drive sales, reviews, and referrals."
            }

            Dim posts() As (Integer, Platform, ContentType, ContentPillar, String, String) = {
                (22, Platform.YouTube,   ContentType.Video,    ContentPillar.ActionSteps,   "10 Ways to Reduce Microplastic Exposure Starting Today",               "Practical how-to video."),
                (23, Platform.Instagram, ContentType.Reel,     ContentPillar.ActionSteps,   "The one kitchen swap that cuts your microplastic intake by 40%.",      "Quick actionable reel."),
                (24, Platform.TikTok,    ContentType.Short,    ContentPillar.ActionSteps,   "Plastic-free morning routine — I show you exactly what I do.",         "Day-in-the-life format."),
                (25, Platform.LinkedIn,  ContentType.Post,     ContentPillar.BookPromotion, "Microplastic Consciousness is now in [X] hands. Here's what readers are saying.", "Milestone + social proof."),
                (26, Platform.Facebook,  ContentType.Post,     ContentPillar.ActionSteps,   "The 3-step plastic detox I recommend in the book. Here's a preview.",  "Value-forward post with CTA."),
                (27, Platform.Threads,   ContentType.Thread,   ContentPillar.ActionSteps,   "Thread: A beginner's guide to reducing microplastic exposure. Save this. 1/8", "Practical thread."),
                (28, Platform.Instagram, ContentType.Reel,     ContentPillar.BookPromotion, "Last 72 hours of the launch offer. Here's why this book matters.",     "Urgency + value reel.")
            }

            For Each p In posts
                week.Posts.Add(New SocialPost With {
                    .Day = p.Item1,
                    .PostDate = StartDate.AddDays(p.Item1 - 1),
                    .Platform = p.Item2,
                    .ContentType = p.Item3,
                    .Pillar = p.Item4,
                    .Hook = p.Item5,
                    .Caption = p.Item6,
                    .CallToAction = "Get your copy now. Link in bio.",
                    .Hashtags = New List(Of String) From {"#MicroplasticConsciousness", "#plasticfree", "#health", "#booklaunch"}
                })
            Next

            Return week
        End Function

        ' ----------------------------------------------------------------
        ' DAYS 29-30 — LAUNCH FINALE
        ' ----------------------------------------------------------------
        Public Shared Function BuildLaunchFinale() As WeekPlan
            Dim week As New WeekPlan With {
                .WeekNumber = 5,
                .Theme = "LAUNCH FINALE — Thank You + What's Next",
                .Goal = "Celebrate. Collect reviews. Set up the next 30-day cycle."
            }

            week.Posts.Add(New SocialPost With {
                .Day = 29,
                .PostDate = StartDate.AddDays(28),
                .Platform = Platform.Instagram,
                .ContentType = ContentType.Reel,
                .Pillar = ContentPillar.Community,
                .Hook = "29 days in. Here's what this community has taught me.",
                .Caption = "30 days ago I launched Microplastic Consciousness into the world. " &
                           "What happened next was beyond anything I expected. " &
                           "Thank you. Genuinely. The conversation continues.",
                .CallToAction = "If the book helped you, please leave a review. It changes everything.",
                .VisualNote = "Montage of community responses, comments, reader photos.",
                .Hashtags = New List(Of String) From {"#MicroplasticConsciousness", "#community", "#gratitude", "#booklaunch"}
            })

            week.Posts.Add(New SocialPost With {
                .Day = 30,
                .PostDate = StartDate.AddDays(29),
                .Platform = Platform.YouTube,
                .ContentType = ContentType.Video,
                .Pillar = ContentPillar.BookPromotion,
                .Hook = "Day 30: What We Built Together — and What Comes Next",
                .Caption = "The 30-day launch of Microplastic Consciousness ends today — but the movement doesn't. " &
                           "In this video I share what the campaign meant, what we accomplished together, " &
                           "and where the Microplastic Consciousness project goes from here. " &
                           "Thank you for being part of this.",
                .CallToAction = "Subscribe. Leave a comment. Grab the book if you haven't yet.",
                .VisualNote = "Emotional, authentic. Author direct-to-camera. Include book cover and reader clips.",
                .Duration = "10-15 min",
                .Hashtags = New List(Of String) From {"#MicroplasticConsciousness", "#booklaunch", "#day30", "#community"}
            })

            Return week
        End Function

        Public Shared Sub PrintCalendar(weeks As List(Of WeekPlan))
            Console.WriteLine()
            Console.WriteLine("=" & New String("="c, 69))
            Console.WriteLine("  30-DAY CONTENT CALENDAR — MICROPLASTIC CONSCIOUSNESS")
            Console.WriteLine($"  Launch Start: {StartDate:MMMM d, yyyy}")
            Console.WriteLine("=" & New String("="c, 69))

            For Each week In weeks
                Console.WriteLine()
                Console.WriteLine($"  WEEK {week.WeekNumber}: {week.Theme}")
                Console.WriteLine($"  GOAL: {week.Goal}")
                Console.WriteLine("  " & New String("─"c, 67))

                For Each post In week.Posts
                    Console.WriteLine()
                    Console.WriteLine($"  DAY {post.Day} — {post.PostDate:ddd MMM d} | {post.Platform} | {post.ContentType}")
                    Console.WriteLine($"  Pillar : {post.Pillar}")
                    Console.WriteLine($"  Hook   : {post.Hook}")
                    If Not String.IsNullOrWhiteSpace(post.Duration) Then
                        Console.WriteLine($"  Length : {post.Duration}")
                    End If
                    Console.WriteLine($"  CTA    : {post.CallToAction}")
                    Console.WriteLine($"  Visual : {post.VisualNote}")
                    Console.WriteLine($"  Tags   : {String.Join(" ", post.Hashtags)}")
                Next

                Console.WriteLine()
                Console.WriteLine("  " & New String("═"c, 67))
            Next
        End Sub

    End Class

End Namespace
