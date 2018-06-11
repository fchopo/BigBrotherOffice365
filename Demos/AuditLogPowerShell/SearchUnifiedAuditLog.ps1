$UserCredential = Get-Credential
$Session = New-PSSession -ConfigurationName Microsoft.Exchange -ConnectionUri https://outlook.office365.com/powershell-liveid/ -Credential $UserCredential -Authentication  Basic -AllowRedirection
Import-PSSession $Session
Search-UnifiedAuditLog -StartDate 6/1/2018 -EndDate 6/5/2018 -RecordType Sharepoint
