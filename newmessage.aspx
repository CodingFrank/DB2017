<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newmessage.aspx.cs" Inherits="newmessage" %>

<!DOCTYPE html>
<html lang="en" class=" is-copy-enabled is-u2f-enabled">
  <head prefix="og: http://ogp.me/ns# fb: http://ogp.me/ns/fb# object: http://ogp.me/ns/object# article: http://ogp.me/ns/article# profile: http://ogp.me/ns/profile#">
    <meta charset='utf-8'>
    <meta content="origin-when-cross-origin" name="referrer" />

    <link href="css/frameworks.css" rel="stylesheet" type="text/css" />
    <link href="css/github1.css" rel="stylesheet" type="text/css"/>
    <script src="js/github1.js" type="text/javascript" ></script>    
    <script src="js/gframeworks.js" type="text/javascript" ></script>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta http-equiv="Content-Language" content="en">
    <meta name="viewport" content="width=device-width">
    
    <title>Leave a message</title>
    <link rel="icon" type="image/x-icon" href="favicon.ico">
  </head>


  <body class="logged-in  env-production windows  page-profile mine">
    <div id="js-pjax-loader-bar" class="pjax-loader-bar"><div class="progress"></div></div>
    <div class="header header-logged-in true" role="banner">
  <div class="container clearfix">

    <a class="header-logo-invertocat" href="index.aspx" data-hotkey="g d" aria-label="Homepage" data-ga-click="Header, go to dashboard, icon:logo">
  <svg height="28" width="28">
  <g id="UrTavla">
  <circle cx="14" cy="14" r="14" fill="green" />
<text x="50%" y="50%" text-anchor="middle" dy=".3em">F</text>
</g>
</svg>
</a>


<div class="header-search   js-site-search" role="search">
  <!-- </textarea> --><!-- '"` --></div>
<ul class="header-nav user-nav float-right" id="user-links">
  <li class="header-nav-item">
    

  </li>

  <li class="header-nav-item dropdown js-menu-container">

  </li>

  <li class="header-nav-item dropdown js-menu-container">
  </li>
</ul>
    <ul class="header-nav float-right" role="navigation">
    <li class="header-nav-item">
        Welcome to Frank's website 
    </li>
    </ul>
  </div>
</div>
    <div id="start-of-content" class="accessibility-aid"></div>
      <div id="js-flash-container">
</div>
    <div role="main">
      <div id="js-pjax-container" data-pjax-container>
  <div class="page-content container">
    <div class="columns profilecols">
      <div class="column one-fourth" itemscope itemtype="http://schema.org/Person">
          <a href="index.aspx" aria-label="Frank is a cool guy" class="vcard-avatar d-block tooltipped tooltipped-s"><img alt="" class="avatar rounded-2" height="307" src="images/FrankLiuatMasterCup.JPG" width="230" /></a>
<h1 class="vcard-names my-3">
  <div class="vcard-fullname" itemprop="name"></div>
  <div class="vcard-username" itemprop="additionalName">Frank Liu's Home Page</div>
</h1>
  <p>
    <a href="newmessage.aspx">Leave a message</a>
  </p>
<ul class="vcard-details border-top border-gray-light py-3">
  <li aria-label="Member since" class="vcard-detail py-1 css-truncate css-truncate-target"><svg aria-hidden="true" class="octicon octicon-clock" height="16" version="1.1" viewBox="0 0 14 16" width="14"><path d="M8 8h3v2H7c-.55 0-1-.45-1-1V4h2v4zM7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7z"></path></svg><span class="join-label">Picture taken on </span><local-time class="join-date" datetime="2007-10-02T02:07:18Z" day="numeric" month="short" year="numeric">Oct 2, 2007</local-time></li>
</ul>


        <div class="vcard-stats border-top border-bottom border-gray-light mb-3 py-3">
          <a class="vcard-stat" href="messages.aspx">
            <strong class="vcard-stat-count d-block"><%=TtlMsg %></strong>
            <span class="text-gray">Messages</span>
          </a>
        </div>

      </div>

              <div class="column three-fourths" style="box-sizing: border-box;">
        <div class="boxed-group">
        <h3>Leave me a message</h3>
        <div class="boxed-group-inner clearfix">
            <form accept-charset="UTF-8" runat="server" class="columns js-uploadable-container js-upload-avatar-image is-default" novalidate="novalidate">
            <div class="column three-fourths">
            <dl class="form-group">
              <dt><label for="user_profile_name">Your Name</label></dt>
              <dd><input class="form-control" id="txt_Name" name="txt_Name"  size="30" type="text" runat="server" /></dd>
            </dl>
            <dl class="form-group">
            <dt><label for="s_jianjie">Your message</label></dt>
            <dd><textarea class="form-control"  cols="40" data-max-length="160" name="txt_Message" id="txt_Message" rows="20"  runat="server"></textarea>
            </dd>
            </dl>
            <p><asp:Button Text="Submit your message" runat="server" OnClick="update" type="submit" class="btn btn-primary"/>
            </p>
            </div>
            </form>
        </div>
        </div>
        </div>

    </div>
  </div>

      </div>
      <div class="modal-backdrop js-touch-events"></div>
    </div>

        <div class="container site-footer-container">
  <div class="site-footer" role="contentinfo">
    <ul class="site-footer-links float-right">
    </ul>

    <a href="index.aspx" aria-label="Homepage" class="site-footer-mark" title="Homepage">
    <svg aria-hidden="true" class="octicon octicon-mark-github" height="24" version="1.1" viewBox="0 0 16 16" width="24">
      <g id="UrTavla1">
      <circle cx="8" cy="8" r="8" fill="green" />
    <text x="50%" y="50%" text-anchor="middle" dy=".3em">F</text>
    </g>
    </svg> 
</a>
    <ul class="site-footer-links">
      <li>&copy; 2016 <span >Built for Software Development</span>, ITWS-6700</li>
    </ul>
  </div>
</div>
    <div class="facebox" id="facebox" style="display:none;">
  <div class="facebox-popup">
    <div class="facebox-content" role="dialog" aria-labelledby="facebox-header" aria-describedby="facebox-description">
    </div>
    <button type="button" class="facebox-close js-facebox-close" aria-label="Close modal">
      <svg aria-hidden="true" class="octicon octicon-x" height="16" version="1.1" viewBox="0 0 12 16" width="12"><path d="M7.48 8l3.75 3.75-1.48 1.48L6 9.48l-3.75 3.75-1.48-1.48L4.52 8 .77 4.25l1.48-1.48L6 6.52l3.75-3.75 1.48 1.48z"></path></svg>
    </button>
  </div>
</div>

  </body>
</html>