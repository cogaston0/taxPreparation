Imports System
Imports MicroplasticMarketing

Module Program

    Sub Main(args As String())
        Console.OutputEncoding = System.Text.Encoding.UTF8

        PrintBanner()

        If args.Length = 0 Then
            PrintMenu()
            RunInteractive()
        Else
            RunCommand(args(0).ToLower())
        End If
    End Sub

    Sub PrintBanner()
        Console.WriteLine()
        Console.WriteLine("╔" & New String("═"c, 69) & "╗")
        Console.WriteLine("║" & "  MICROPLASTIC CONSCIOUSNESS — SOCIAL MEDIA MARKETING SYSTEM  ".PadRight(69) & "║")
        Console.WriteLine("║" & "  By Carlos Olivencia | Built in Visual Basic .NET             ".PadRight(69) & "║")
        Console.WriteLine("╚" & New String("═"c, 69) & "╝")
        Console.WriteLine()
    End Sub

    Sub PrintMenu()
        Console.WriteLine("  Available commands:")
        Console.WriteLine()
        Console.WriteLine("   calendar     — Print the full 30-day content calendar")
        Console.WriteLine("   week1        — Print Week 1 content in detail (all platforms)")
        Console.WriteLine("   hooks        — Print all 15 short-form video hooks")
        Console.WriteLine("   captions     — Print the full caption bank (all platforms)")
        Console.WriteLine("   outreach     — Print podcast, media & partner outreach templates")
        Console.WriteLine("   checklist    — Print weekly execution checklists")
        Console.WriteLine("   platforms    — Print the platform system (n8n + Buffer)")
        Console.WriteLine("   all          — Print everything")
        Console.WriteLine()
        Console.WriteLine("  Usage:  dotnet run -- <command>")
        Console.WriteLine("  Example: dotnet run -- calendar")
        Console.WriteLine()
    End Sub

    Sub RunInteractive()
        Console.Write("  Enter command (or 'all'): ")
        Dim input = Console.ReadLine()?.Trim().ToLower()
        If Not String.IsNullOrEmpty(input) Then
            RunCommand(input)
        End If
    End Sub

    Sub RunCommand(command As String)
        Select Case command
            Case "calendar"
                PrintCalendar()
            Case "week1"
                PrintWeek1()
            Case "hooks"
                VideoHooksGenerator.PrintHooks(VideoHooksGenerator.GetAllHooks())
            Case "captions"
                CaptionBank.PrintCaptionBank()
            Case "outreach"
                OutreachTemplates.PrintOutreachTemplates()
            Case "checklist"
                ExecutionChecklist.PrintWeeklyChecklist()
            Case "platforms"
                ExecutionChecklist.PrintPlatformSystem()
            Case "all"
                PrintCalendar()
                PrintWeek1()
                VideoHooksGenerator.PrintHooks(VideoHooksGenerator.GetAllHooks())
                CaptionBank.PrintCaptionBank()
                OutreachTemplates.PrintOutreachTemplates()
                ExecutionChecklist.PrintWeeklyChecklist()
                ExecutionChecklist.PrintPlatformSystem()
                PrintMasterIndex()
            Case Else
                Console.WriteLine($"  Unknown command: '{command}'")
                PrintMenu()
        End Select
    End Sub

    Sub PrintCalendar()
        Dim weeks As New List(Of WeekPlan) From {
            ContentCalendar.BuildWeek1(),
            ContentCalendar.BuildWeek2(),
            ContentCalendar.BuildWeek3(),
            ContentCalendar.BuildWeek4(),
            ContentCalendar.BuildLaunchFinale()
        }
        ContentCalendar.PrintCalendar(weeks)
    End Sub

    Sub PrintWeek1()
        Console.WriteLine()
        Console.WriteLine("=" & New String("="c, 69))
        Console.WriteLine("  WEEK 1 — FULL DETAIL (ALL PLATFORMS)")
        Console.WriteLine("  Theme: AWARENESS — Introducing the Problem")
        Console.WriteLine("=" & New String("="c, 69))

        Dim week1 = ContentCalendar.BuildWeek1()
        For Each post In week1.Posts
            Console.WriteLine()
            Console.WriteLine($"  ▶ DAY {post.Day} | {post.Platform} | {post.ContentType} | Pillar: {post.Pillar}")
            Console.WriteLine($"  HOOK    : {post.Hook}")
            Console.WriteLine($"  CAPTION :")
            For Each line In post.Caption.Split(". ")
                Console.WriteLine($"    {line}.")
            Next
            If Not String.IsNullOrWhiteSpace(post.Duration) Then
                Console.WriteLine($"  LENGTH  : {post.Duration}")
            End If
            Console.WriteLine($"  CTA     : {post.CallToAction}")
            Console.WriteLine($"  VISUAL  : {post.VisualNote}")
            Console.WriteLine($"  TAGS    : {String.Join(" ", post.Hashtags)}")
            Console.WriteLine("  " & New String("─"c, 67))
        Next
    End Sub

    Sub PrintMasterIndex()
        Console.WriteLine()
        Console.WriteLine("=" & New String("="c, 69))
        Console.WriteLine("  MASTER INDEX — MICROPLASTIC CONSCIOUSNESS MARKETING SYSTEM")
        Console.WriteLine("=" & New String("="c, 69))
        Console.WriteLine()
        Console.WriteLine("  MODULE                    FILE")
        Console.WriteLine("  " & New String("─"c, 67))
        Console.WriteLine("  Data Models               Models.vb")
        Console.WriteLine("  30-Day Content Calendar   ContentCalendar.vb")
        Console.WriteLine("  15 Video Hooks            VideoHooks.vb")
        Console.WriteLine("  Caption Bank              CaptionBank.vb")
        Console.WriteLine("  Outreach Templates        OutreachTemplates.vb")
        Console.WriteLine("  Execution Checklists      ExecutionChecklist.vb")
        Console.WriteLine("  Main Program / CLI        Program.vb")
        Console.WriteLine()
        Console.WriteLine("  DELIVERABLES INCLUDED")
        Console.WriteLine("  " & New String("─"c, 67))
        Console.WriteLine("  ✓ 30-day content calendar (6 platforms, 30+ posts)")
        Console.WriteLine("  ✓ Week 1 full detail — Instagram, TikTok, YouTube,")
        Console.WriteLine("    Facebook, LinkedIn, Threads")
        Console.WriteLine("  ✓ 15 short-form video hooks")
        Console.WriteLine("  ✓ Caption bank (30+ captions across all platforms)")
        Console.WriteLine("  ✓ Podcast outreach templates (email + DM)")
        Console.WriteLine("  ✓ Media / press outreach template")
        Console.WriteLine("  ✓ Partner & influencer outreach templates")
        Console.WriteLine("  ✓ Weekly execution checklists (5 weeks)")
        Console.WriteLine("  ✓ Platform system: n8n + Buffer workflow guide")
        Console.WriteLine()
        Console.WriteLine("  AUTOMATION STACK")
        Console.WriteLine("  " & New String("─"c, 67))
        Console.WriteLine("  n8n     — Workflow automation (content pipeline, reminders)")
        Console.WriteLine("  Buffer  — Post scheduling (Instagram, Facebook, LinkedIn, Threads)")
        Console.WriteLine()
    End Sub

End Module
