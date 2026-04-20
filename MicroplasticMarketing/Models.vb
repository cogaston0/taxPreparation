Namespace MicroplasticMarketing

    Public Enum Platform
        Instagram
        TikTok
        YouTube
        Facebook
        LinkedIn
        Threads
    End Enum

    Public Enum ContentType
        Reel
        Post
        Story
        Short
        Video
        Thread
        Carousel
        LiveSession
        Podcast
        Poll
    End Enum

    Public Enum ContentPillar
        Awareness       ' What are microplastics?
        Science         ' Research & data
        PersonalStory   ' Author narrative
        ActionSteps     ' What readers can do
        BookPromotion   ' Direct book content
        Community       ' Audience engagement
        BehindScenes    ' Author behind the scenes
    End Enum

    Public Class SocialPost
        Public Property Day As Integer
        Public Property PostDate As DateTime
        Public Property Platform As Platform
        Public Property ContentType As ContentType
        Public Property Pillar As ContentPillar
        Public Property Hook As String
        Public Property Caption As String
        Public Property Hashtags As List(Of String)
        Public Property CallToAction As String
        Public Property VisualNote As String
        Public Property Duration As String  ' For video content

        Public Sub New()
            Hashtags = New List(Of String)
        End Sub

        Public Overrides Function ToString() As String
            Return $"Day {Day} | {Platform} | {ContentType} | {Pillar}"
        End Function
    End Class

    Public Class WeekPlan
        Public Property WeekNumber As Integer
        Public Property Theme As String
        Public Property Goal As String
        Public Property Posts As List(Of SocialPost)

        Public Sub New()
            Posts = New List(Of SocialPost)()
        End Sub
    End Class

    Public Class OutreachMessage
        Public Property TargetType As String  ' Podcast, Media, Partner
        Public Property Subject As String
        Public Property Body As String
        Public Property Platform As String
    End Class

    Public Class VideoHook
        Public Property Number As Integer
        Public Property Hook As String
        Public Property Platform As String
        Public Property Style As String
    End Class

End Namespace
