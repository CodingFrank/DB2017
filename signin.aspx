<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signin.aspx.cs" Inherits="signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="stylesheet" href="css/bootstrap-3.3.7-dist/css/bootstrap.min.css">
	<link rel="stylesheet" href="css/landing.css">
	<link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:600" rel="stylesheet">
    <title>Please sign in</title>
</head>
	<body>
		<div class="container">
			<div class="row">
				<div class="col-xs-3">
				</div>
				<div class="col-xs-6" id="middle-column">
					<div class="col-xs-12" id="sign-in">
						<img id="logo" src="images/Microsoft-Logo-icon-png-Transparent-Background.png">
						<h1 id="title">Sentiment Analysis</h1>
					</div>	
					<div class="col-xs-12">
						<form method="post" action="cases.html" runat="server">
							<input type="text" name="microsoft-id" placeholder="Microsoft ID">
							<br>
							<br>
							<input type="text" name="case-id" placeholder="Case ID">
							<br>
							<br>
							<input id="submit-signin" type="submit" value="Sign In">
						</form>
					</div>
				</div>
				<div class="col-xs-3">
				</div>
			</div>
		</div>
		
	</body>
</html>
