Imports Nethereum.Web3
Imports Nethereum.ENS


Public Class MainForm
    Private Async Sub testContract()

        Dim iweb3 = New Web3("https://cloudflare-eth.com")
        Dim ensService = New ENSService(iweb3)

        Dim content = Await ensService.GetContentHashAsync(TextBox1.Text.Trim()) 'need to
        If content Is Nothing Then
            TextBox2.Text = "Nada"
        Else
            If content.Length = 0 Then
                TextBox2.Text = "Doesn't seem to have a contentHash/ipfs address"
            Else
                If content(0) = &HE3 Then
                    Dim cid = IPLD.ContentIdentifier.Cid.Cast(content.Skip(2).ToArray())
                    Dim decoded = cid.Hash.B58String() 'lol naw this ain't obsolete yo, don't wanna convert to base58 myself
                    TextBox2.Text = decoded
                End If
            End If
        End If

    End Sub

    Private Sub btnExec_Click(sender As Object, e As EventArgs) Handles btnExec.Click
        Call testContract()
    End Sub
End Class