Imports manishagunData.Manishagun.Data
Imports manishagun.Manishagun.Web
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Home

    Function Index() As ActionResult
        Return View()
    End Function

    Function AboutUs() As ActionResult
        Return View()
    End Function

    Function ManuharPatrika() As ActionResult
        Return View()
    End Function

    Function GuestBook() As ActionResult
        Return View()
    End Function

    Function GuestBookMiddle(currentPageNumber As Integer, IsNext As Boolean) As ActionResult

        Dim GuestBookMessages As MSGuestBook()
        Dim GuestBookMiddleData As New GuestBookMiddleModel
        Dim GuestBookMessageLeft As MSGuestBook = Nothing
        Dim GuestBookMessageRight As MSGuestBook = Nothing
        Dim skiptCount, TotalMessageCount As Integer

        If Not currentPageNumber < 0 Then

            If IsNext Then
                skiptCount = currentPageNumber * 2
                currentPageNumber += 1
            Else
                currentPageNumber -= 1
                skiptCount = (currentPageNumber - 1) * 2
            End If

        End If

        Using gbd As New GuestBookDirector
            GuestBookMessages = gbd.GetGuestBookMessages().OrderByDescending(Function(s) s.DateCreated).Skip(skiptCount).Take(2).ToArray
            TotalMessageCount = gbd.GetGuestBookMessages().Count

            With GuestBookMiddleData

                .MessageCount = TotalMessageCount

                GuestBookMessageLeft = GuestBookMessages.FirstOrDefault
                If GuestBookMessages.Count > 1 Then GuestBookMessageRight = GuestBookMessages.LastOrDefault

                If GuestBookMessageLeft IsNot Nothing Then

                    .MessageLeftName = GuestBookMessageLeft.Name
                    .MessageLeftNote = GuestBookMessageLeft.Message
                    .MessageLeftTime = GetFormattedTime(GuestBookMessageLeft.DateCreated)

                End If

                If GuestBookMessageRight IsNot Nothing Then

                    .MessageRightName = GuestBookMessageRight.Name
                    .MessageRightNote = GuestBookMessageRight.Message
                    .MessageRightTime = GetFormattedTime(GuestBookMessageRight.DateCreated)

                End If

                .PageNumber = currentPageNumber

                If TotalMessageCount > skiptCount + 2 Then
                    .IsNextAvailable = True
                End If

                If currentPageNumber > 1 Then
                    .IsPreviousAvailable = True
                End If

            End With

        End Using

        Return View(GuestBookMiddleData)
    End Function

    Sub SaveGuestBookMessage(name As String, msg As String)

        Using gbd As New GuestBookDirector
            gbd.InsertMessage(name.Replace("&lt;", Chr(60)).Replace("&gt;", Chr(62)).Replace("&amp;", Chr(38)), msg.Replace("&lt;", Chr(60)).Replace("&gt;", Chr(62)).Replace("&amp;", Chr(38)))
        End Using

    End Sub


#Region "Private Functions"
    Private Function GetFormattedTime(msgDate As Date) As String
        Dim timeDifference As TimeSpan = Now - msgDate

        Dim totalDays As Integer = timeDifference.Days
        Dim totalSeconds, totalMinutes, totalHrs As Integer

        Dim timediff As String = ""

        If totalDays > 0 Then

            If totalDays > 7 Then

                If totalDays > 30 Then

                    If totalDays / 30 > 1 Then

                        timediff = Math.Ceiling(totalDays / 30) & " months"

                    Else

                        timediff = Math.Ceiling(totalDays / 30) & " month"

                    End If

                Else

                    timediff = Math.Ceiling(totalDays / 7) & " weeks"

                End If

            Else

                If totalDays > 1 Then

                    timediff = totalDays & " days"

                Else

                    timediff = totalDays & " day"

                End If

            End If

        Else

            totalHrs = timeDifference.Hours

            If totalHrs > 0 Then

                timediff = totalHrs & " hours"
            Else
                totalMinutes = timeDifference.Minutes

                If totalMinutes > 0 Then
                    timediff = totalMinutes & " minutes"
                Else
                    totalSeconds = timeDifference.Seconds
                    timediff = totalSeconds & " seconds"
                End If

            End If

        End If

        Return "about " & timediff & " ago"

    End Function

#End Region


End Class