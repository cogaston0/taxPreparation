Namespace MicroplasticMarketing

    Public Class VideoHooksGenerator

        Public Shared Function GetAllHooks() As List(Of VideoHook)
            Dim hooks As New List(Of VideoHook)()

            hooks.Add(New VideoHook With {
                .Number = 1,
                .Hook = "You've swallowed a credit card worth of plastic this week — and it's changing your brain.",
                .Platform = "TikTok / Reels / Shorts",
                .Style = "Shock Stat"
            })
            hooks.Add(New VideoHook With {
                .Number = 2,
                .Hook = "Scientists just found microplastics inside human brain tissue. Here's what that actually means.",
                .Platform = "TikTok / Reels / Shorts",
                .Style = "Breaking News"
            })
            hooks.Add(New VideoHook With {
                .Number = 3,
                .Hook = "I wrote a book about microplastics. What I found changed the way I eat, breathe, and think.",
                .Platform = "All Platforms",
                .Style = "Personal Story"
            })
            hooks.Add(New VideoHook With {
                .Number = 4,
                .Hook = "POV: You find out the bottled water you've been drinking for years is full of plastic particles.",
                .Platform = "TikTok / Reels",
                .Style = "POV"
            })
            hooks.Add(New VideoHook With {
                .Number = 5,
                .Hook = "Nobody is talking about what microplastics do to your hormones. Let me change that.",
                .Platform = "YouTube / TikTok",
                .Style = "Contrarian"
            })
            hooks.Add(New VideoHook With {
                .Number = 6,
                .Hook = "3 things in your kitchen RIGHT NOW that are flooding your body with microplastics.",
                .Platform = "TikTok / Reels / Shorts",
                .Style = "List / Listicle"
            })
            hooks.Add(New VideoHook With {
                .Number = 7,
                .Hook = "This is not a scare tactic. This is the science your doctor hasn't told you yet.",
                .Platform = "YouTube / LinkedIn",
                .Style = "Credibility"
            })
            hooks.Add(New VideoHook With {
                .Number = 8,
                .Hook = "What if consciousness itself is being shaped by what we put in our bodies?",
                .Platform = "YouTube / Instagram",
                .Style = "Philosophical"
            })
            hooks.Add(New VideoHook With {
                .Number = 9,
                .Hook = "The research is in. Microplastics are now found in every organ of the human body — including yours.",
                .Platform = "All Platforms",
                .Style = "Research Drop"
            })
            hooks.Add(New VideoHook With {
                .Number = 10,
                .Hook = "I stopped using plastic for 30 days. Here's what happened to my body.",
                .Platform = "TikTok / YouTube",
                .Style = "Challenge / Experiment"
            })
            hooks.Add(New VideoHook With {
                .Number = 11,
                .Hook = "Microplastic Consciousness isn't just a book title — it's a survival skill for the 21st century.",
                .Platform = "Instagram / Threads / LinkedIn",
                .Style = "Brand Statement"
            })
            hooks.Add(New VideoHook With {
                .Number = 12,
                .Hook = "They put it in your food. They put it in your water. Now it's in your bloodstream. Wake up.",
                .Platform = "TikTok / Facebook",
                .Style = "Urgency"
            })
            hooks.Add(New VideoHook With {
                .Number = 13,
                .Hook = "Here's the one swap you can make TODAY that cuts your microplastic exposure by 40%.",
                .Platform = "All Platforms",
                .Style = "Action / Quick Win"
            })
            hooks.Add(New VideoHook With {
                .Number = 14,
                .Hook = "Imagine living in a body free of synthetic contamination. That future is possible — here's how.",
                .Platform = "Instagram / YouTube",
                .Style = "Aspirational"
            })
            hooks.Add(New VideoHook With {
                .Number = 15,
                .Hook = "The plastic industry knew. And they didn't tell us. This book tells the story they buried.",
                .Platform = "YouTube / Facebook / LinkedIn",
                .Style = "Investigative"
            })

            Return hooks
        End Function

        Public Shared Sub PrintHooks(hooks As List(Of VideoHook))
            Console.WriteLine()
            Console.WriteLine("=" & New String("="c, 69))
            Console.WriteLine("  15 SHORT-FORM VIDEO HOOKS — MICROPLASTIC CONSCIOUSNESS")
            Console.WriteLine("=" & New String("="c, 69))

            For Each h In hooks
                Console.WriteLine()
                Console.WriteLine($"  HOOK #{h.Number}  [{h.Style}]")
                Console.WriteLine($"  Platform: {h.Platform}")
                Console.WriteLine($"  ""{h.Hook}""")
                Console.WriteLine("  " & New String("-"c, 67))
            Next
        End Sub

    End Class

End Namespace
