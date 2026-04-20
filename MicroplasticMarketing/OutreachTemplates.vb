Namespace MicroplasticMarketing

    Public Class OutreachTemplates

        Public Shared Function GetPodcastOutreach() As List(Of OutreachMessage)
            Dim messages As New List(Of OutreachMessage)()

            messages.Add(New OutreachMessage With {
                .TargetType = "Podcast",
                .Platform = "Email / DM",
                .Subject = "Guest Pitch: Microplastics, Human Health & Conscious Living — Carlos Olivencia",
                .Body =
                "Hi [Host Name]," & Environment.NewLine & Environment.NewLine &
                "My name is Carlos Olivencia, and I'm the author of Microplastic Consciousness — " &
                "a research-backed book exploring how microplastic contamination is affecting human health, " &
                "cognition, and our relationship with the environment." & Environment.NewLine & Environment.NewLine &
                "I've been following [Podcast Name] and think this topic would resonate deeply with your audience, " &
                "especially given your focus on [wellness / science / sustainability / health]." & Environment.NewLine & Environment.NewLine &
                "Here's what I could bring to an episode:" & Environment.NewLine &
                "• The latest science on microplastics in the human brain, blood, and organs" & Environment.NewLine &
                "• Practical, accessible steps listeners can take to reduce exposure" & Environment.NewLine &
                "• The bigger picture: what microplastic saturation means for consciousness and modern living" & Environment.NewLine & Environment.NewLine &
                "I'm happy to send a copy of the book in advance. Would love to connect." & Environment.NewLine & Environment.NewLine &
                "Warm regards," & Environment.NewLine &
                "Carlos Olivencia" & Environment.NewLine &
                "Author, Microplastic Consciousness" & Environment.NewLine &
                "[Website] | [Social Handle]"
            })

            messages.Add(New OutreachMessage With {
                .TargetType = "Podcast",
                .Platform = "Instagram DM",
                .Subject = "N/A — Direct Message",
                .Body =
                "Hey [Host] — love what you're building with [Podcast Name]. " &
                "I wrote a book called Microplastic Consciousness — it covers the science of how plastic is literally inside " &
                "us now (brain tissue, blood, lungs) and what that means for health and awareness. " &
                "Think it'd be a great fit for your audience. " &
                "Open to a 20-min call to see if it works? Happy to send the book over first."
            })

            Return messages
        End Function

        Public Shared Function GetMediaOutreach() As List(Of OutreachMessage)
            Dim messages As New List(Of OutreachMessage)()

            messages.Add(New OutreachMessage With {
                .TargetType = "Media / Press",
                .Platform = "Email",
                .Subject = "Press Inquiry: New Book Connects Microplastic Science to Human Consciousness",
                .Body =
                "Dear [Editor / Journalist Name]," & Environment.NewLine & Environment.NewLine &
                "I'm reaching out about a story angle I believe your readers would find compelling." & Environment.NewLine & Environment.NewLine &
                "My newly published book, Microplastic Consciousness, bridges peer-reviewed environmental science " &
                "with the lived human experience of contamination — covering recent findings including microplastics " &
                "discovered in brain tissue, bloodstreams, and major organs." & Environment.NewLine & Environment.NewLine &
                "Key angles for your coverage:" & Environment.NewLine &
                "• What the 2024–2025 research wave tells us about microplastics and neurological health" & Environment.NewLine &
                "• Why ""microplastic consciousness"" is emerging as a framework for environmental awareness" & Environment.NewLine &
                "• The personal narrative behind the research — and what it means for everyday consumers" & Environment.NewLine & Environment.NewLine &
                "I'm available for interviews, quotes, and can provide a review copy. " &
                "Please let me know if this fits your editorial calendar." & Environment.NewLine & Environment.NewLine &
                "Best," & Environment.NewLine &
                "Carlos Olivencia" & Environment.NewLine &
                "Author, Microplastic Consciousness"
            })

            Return messages
        End Function

        Public Shared Function GetPartnerOutreach() As List(Of OutreachMessage)
            Dim messages As New List(Of OutreachMessage)()

            messages.Add(New OutreachMessage With {
                .TargetType = "Partner Organization",
                .Platform = "Email",
                .Subject = "Partnership Opportunity — Microplastic Consciousness + [Organization Name]",
                .Body =
                "Hello [Contact Name]," & Environment.NewLine & Environment.NewLine &
                "I'm Carlos Olivencia, author of Microplastic Consciousness — " &
                "a book dedicated to raising public awareness about microplastic contamination " &
                "and empowering people to make informed choices." & Environment.NewLine & Environment.NewLine &
                "I believe there's a meaningful opportunity for collaboration between our missions. " &
                "Specifically, I'd love to explore:" & Environment.NewLine &
                "• Co-branded educational content for your community" & Environment.NewLine &
                "• Speaking at your events or webinars" & Environment.NewLine &
                "• Bundle offers or joint promotions to shared audiences" & Environment.NewLine &
                "• Cross-promotion on social channels" & Environment.NewLine & Environment.NewLine &
                "Our audiences are aligned — people who care about their health, the environment, " &
                "and taking meaningful action. I believe we can do more together than apart." & Environment.NewLine & Environment.NewLine &
                "Would you be open to a brief call this week or next?" & Environment.NewLine & Environment.NewLine &
                "Thank you for your work and your time." & Environment.NewLine & Environment.NewLine &
                "Carlos Olivencia" & Environment.NewLine &
                "Author, Microplastic Consciousness"
            })

            messages.Add(New OutreachMessage With {
                .TargetType = "Influencer / Creator",
                .Platform = "DM / Email",
                .Subject = "Book Collab — Microplastic Consciousness",
                .Body =
                "Hey [Creator Name]," & Environment.NewLine & Environment.NewLine &
                "Big fan of your content — especially [specific post/video]. " &
                "You've built such a genuine community around [health / wellness / environment]." & Environment.NewLine & Environment.NewLine &
                "I wrote a book called Microplastic Consciousness that I think your audience would love. " &
                "It's about the science of microplastics in the human body — and what we can actually do about it. " &
                "Not doom and gloom — real, actionable awareness." & Environment.NewLine & Environment.NewLine &
                "Would love to send you a copy, no strings attached. " &
                "If it resonates, maybe we find a way to share it together. " &
                "If not, no worries at all." & Environment.NewLine & Environment.NewLine &
                "Either way — keep doing what you're doing." & Environment.NewLine & Environment.NewLine &
                "Carlos"
            })

            Return messages
        End Function

        Public Shared Sub PrintOutreachTemplates()
            Console.WriteLine()
            Console.WriteLine("=" & New String("="c, 69))
            Console.WriteLine("  OUTREACH TEMPLATES — MICROPLASTIC CONSCIOUSNESS")
            Console.WriteLine("=" & New String("="c, 69))

            Dim allMessages As New List(Of OutreachMessage)()
            allMessages.AddRange(GetPodcastOutreach())
            allMessages.AddRange(GetMediaOutreach())
            allMessages.AddRange(GetPartnerOutreach())

            For Each msg In allMessages
                Console.WriteLine()
                Console.WriteLine($"  TYPE: {msg.TargetType}")
                Console.WriteLine($"  PLATFORM: {msg.Platform}")
                If msg.Subject <> "N/A — Direct Message" Then
                    Console.WriteLine($"  SUBJECT: {msg.Subject}")
                End If
                Console.WriteLine()
                Console.WriteLine("  MESSAGE:")
                For Each line In msg.Body.Split(Environment.NewLine)
                    Console.WriteLine($"  {line}")
                Next
                Console.WriteLine("  " & New String("-"c, 67))
            Next
        End Sub

    End Class

End Namespace
