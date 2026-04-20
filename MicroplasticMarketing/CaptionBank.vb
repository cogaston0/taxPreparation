Namespace MicroplasticMarketing

    Public Class CaptionBank

        Public Shared Function GetInstagramCaptions() As List(Of String)
            Return New List(Of String) From {
                "Your body is not a waste bin — but the plastic industry has been treating it like one for decades. " &
                "Microplastic Consciousness is the wake-up call we all need. Link in bio.",

                "We eat. We drink. We breathe. And somewhere in every one of those acts, plastic enters us. " &
                "This book unpacks what that means — scientifically, spiritually, and practically. " &
                "Are you ready to know? #MicroplasticConsciousness",

                "Awareness is the first detox. " &
                "Before you can change your relationship with plastic, you have to understand what it's doing to you. " &
                "That's what this book is for. " &
                "Grab your copy — link in bio.",

                "New research confirms microplastics in the human brain. " &
                "Not in the future. Now. In people alive today. " &
                "If that doesn't shift your consciousness, nothing will. #KnowBetter",

                "Small steps, compounded over time, create a cleaner body and a clearer mind. " &
                "Microplastic Consciousness gives you the roadmap. Start today."
            }
        End Function

        Public Shared Function GetTikTokCaptions() As List(Of String)
            Return New List(Of String) From {
                "This is what they don't teach in school 🧠 #microplastics #health #consciousness #booktok",
                "The science is terrifying but the solutions are real. Let's talk about it. #microplasticawareness #healthtok",
                "I spent years researching this. Here's what changed my life. #MicroplasticConsciousness #nonfiction",
                "Your brain on plastics vs your brain without them — the difference is real. #toxinfree #wellness",
                "Not fear. Just facts. And a path forward. #microplastics #healthylifestyle #bookrecommendation"
            }
        End Function

        Public Shared Function GetLinkedInCaptions() As List(Of String)
            Return New List(Of String) From {
                "Environmental health is now a leadership issue. " &
                "As organizations commit to sustainability, the conversation must extend inward — to the bodies of the people doing the work. " &
                "Microplastic Consciousness explores the intersection of environmental science, human health, and conscious living. " &
                "Recommended reading for anyone serious about the future.",

                "Peer-reviewed research now confirms microplastic contamination in human blood, lungs, liver, and brain tissue. " &
                "The question is no longer whether this affects us — it's how we respond. " &
                "My new book offers a science-grounded, action-oriented framework. " &
                "Details in the comments.",

                "We talk endlessly about digital transformation. " &
                "But what about biological transformation — driven by the materials we've unknowingly introduced into our bodies? " &
                "Microplastic Consciousness is a book about waking up to what we've been ignoring.",

                "If you work in sustainability, public health, education, or policy — this book is for you. " &
                "Not because it has all the answers, but because it asks the right questions."
            }
        End Function

        Public Shared Function GetThreadsCaptions() As List(Of String)
            Return New List(Of String) From {
                "Hot take: microplastics are the defining environmental health crisis of our generation and we're still debating whether they're real.",
                "The book I wish existed when I started asking questions about plastic and the human body — so I wrote it. Microplastic Consciousness.",
                "Consciousness shifts when information reaches you that you can't un-know. That's this book.",
                "Thread incoming: 5 things microplastics do to your body that most people don't know about. 1/6",
                "You don't have to be perfect. You just have to be aware. That's where it starts. #MicroplasticConsciousness"
            }
        End Function

        Public Shared Function GetFacebookCaptions() As List(Of String)
            Return New List(Of String) From {
                "For everyone who has ever asked ""what can I actually DO about the plastic problem?"" — this book is my answer. " &
                "It covers the science, the personal impact, and the practical steps you can take starting today. " &
                "Microplastic Consciousness is available now. Share with someone who needs to read this.",

                "I know this topic can feel overwhelming. " &
                "That's exactly why I wrote Microplastic Consciousness — not to add to the anxiety, " &
                "but to give you grounded, research-backed information and real solutions. " &
                "Join the conversation in the comments.",

                "Did you know the average person consumes approximately 5 grams of plastic per week? " &
                "That's the weight of a credit card — every single week — entering your body. " &
                "It's time to talk about what that means. Link to the book below."
            }
        End Function

        Public Shared Function GetYouTubeCaptions() As List(Of String)
            Return New List(Of String) From {
                "In this video, I break down the key findings from Microplastic Consciousness — " &
                "the science behind microplastic contamination in the human body, what the latest research says, " &
                "and the practical steps you can take to reduce your exposure. " &
                "This is not a scare video. This is a knowledge video. " &
                "Timestamps below. Subscribe for weekly updates on conscious living and environmental health.",

                "What does it mean to live consciously in a world saturated with synthetic materials? " &
                "In today's video, I'm sharing the origin story of Microplastic Consciousness — " &
                "why I wrote it, what I discovered, and why I believe this conversation can't wait any longer. " &
                "Watch to the end for a free chapter preview.",

                "The research is clear. Microplastics are inside us. " &
                "But the story doesn't end there — it begins. " &
                "This is the full breakdown of what the science says and what we can do about it. " &
                "Microplastic Consciousness is available wherever books are sold. Link in description."
            }
        End Function

        Public Shared Sub PrintCaptionBank()
            Console.WriteLine()
            Console.WriteLine("=" & New String("="c, 69))
            Console.WriteLine("  CAPTION BANK — MICROPLASTIC CONSCIOUSNESS")
            Console.WriteLine("=" & New String("="c, 69))

            Dim sections As New Dictionary(Of String, List(Of String)) From {
                {"INSTAGRAM", GetInstagramCaptions()},
                {"TIKTOK", GetTikTokCaptions()},
                {"LINKEDIN", GetLinkedInCaptions()},
                {"THREADS", GetThreadsCaptions()},
                {"FACEBOOK", GetFacebookCaptions()},
                {"YOUTUBE", GetYouTubeCaptions()}
            }

            For Each section In sections
                Console.WriteLine()
                Console.WriteLine($"  --- {section.Key} ---")
                Dim i As Integer = 1
                For Each caption In section.Value
                    Console.WriteLine()
                    Console.WriteLine($"  Caption {i}:")
                    Console.WriteLine($"  {caption}")
                    i += 1
                Next
            Next
        End Sub

    End Class

End Namespace
