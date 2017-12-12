<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cases.aspx.cs" Inherits="cases" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cases under your name</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="stylesheet" href="css/bootstrap-3.3.7-dist/css/bootstrap.min.css">
	<link rel="stylesheet" href="css/main-grid.css">
</head>
<body>
    <form id="form1" runat="server">
		<div class="container-fluid">
			<div class="row">
				<div class="col-xs-9" id="content-left"> <!-- Left 3/4 of screen dedicated to content blocks for calls or cases -->
					
					<div class="col-xs-12 content-block" ><!--content block, contains call or case information and iconography, and sentiment indicator-->
						<div class="col-xs-11 content-info"></div>
						<div class="col-xs-1 sentiment-indicator"></div>
					</div>
					
					
					<div class="col-xs-12 content-block">
						<div class="col-xs-11 content-info"></div>
						<div class="col-xs-1 sentiment-indicator"></div>
					</div>
						
						
					<div class="col-xs-12 content-block">
						<div class="col-xs-11 content-info"></div>
						<div class="col-xs-1 sentiment-indicator"></div>
					</div>
						
						
				</div>
				<div class="col-xs-3" id="profile-right">
				</div>
			</div>
		</div>    </form>
</body>
</html>
