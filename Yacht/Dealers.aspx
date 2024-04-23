<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dealers.aspx.cs" Inherits="Yacht.Dealers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>TtayanaWorld (DEMO)</title>
    <script type="text/javascript" src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.cycle.all.2.74.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.slideshow').cycle({
                fx: 'fade' // choose your transition type, ex: fade, scrollUp, shuffle, etc...
            });
        });
    </script>
    <!--[if lt IE 7]>
<script type="text/javascript" src="javascript/iepngfix_tilebg.js"></script>
<![endif]-->
    <link href="Yatchassets/css/homestyle.css" rel="stylesheet" type="text/css" />
    <link href="Yatchassets/css/reset.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="contain">
            <div class="sub">
                <p><a href="Index.aspx">Home</a></p>
            </div>

            <!--------------------------------選單開始---------------------------------------------------->
          <%--  <div class="menu">
                <ul>
                    <li class="menuli01"><a href="#">Yachts</a></li>
                    <li class="menuli02"><a href="#">NEWS</a></li>
                    <li class="menuli03"><a href="#">COMPANY</a></li>
                    <li class="menuli04"><a href="#">DEALERS</a></li>
                    <li class="menuli05"><a href="#">CONTACT</a></li>
                </ul>
            </div>--%>
                        <div class="menu">
                <ul>
                    <li class="menuli01"><a href="Yachts.aspx">
                        <img src="Yatchassets/images/mmmmeeeee.gif" alt="&quot;&quot;" />Yachts</a></li>
                    <li class="menuli02"><a href="News.aspx">
                        <img src="Yatchassets/images/mmmmeeeee.gif" alt="&quot;&quot;" />NEWS</a></li>
                    <li class="menuli03"><a href="AboutUs.aspx">
                        <img src="Yatchassets/images/mmmmeeeee.gif" alt="&quot;&quot;" />COMPANY</a></li>
                    <li class="menuli04"><a href="Dealers.aspx">
                        <img src="Yatchassets/images/mmmmeeeee.gif" alt="&quot;&quot;" />DEALERS</a></li>
                    <li class="menuli05"><a href="Contect.aspx">
                        <img src="Yatchassets/images/mmmmeeeee.gif" alt="&quot;&quot;" />CONTACT</a></li>
                </ul>
            </div>
            <!--------------------------------選單開始結束---------------------------------------------------->

            <!--遮罩-->
            <div class="bannermasks">
                <img src="Yatchassets/images/DEALERS.jpg" alt="&quot;&quot;" width="967" height="371" />
            </div>
            <!--遮罩結束-->

            <!--<div id="buttom01"><a href="#"><img src="images/buttom01.gif" alt="next" /></a></div>-->

            <!--小圖開始-->
            <!--<div class="bannerimg">
<ul>
<li> <a href="#"><div class="on"><p class="bannerimg_p"><img  src="images/pit003.jpg" alt="&quot;&quot;" /></p></div></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" width="300" /></p>
</a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
</ul>

<ul>
<li> <a class="on" href="#"><p class="bannerimg_p"><img  src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <p class="bannerimg_p"><a href="#"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
</ul>


</div>-->
            <!--小圖結束-->


            <!--<div id="buttom02"> <a href="#"><img src="images/buttom02.gif" alt="next" /></a></div>-->

            <!--------------------------------換圖開始---------------------------------------------------->

            <div class="banner">
                <ul>
                    <li>
                        <img src="Yatchassets/images/newbanner.jpg" alt="Tayana Yachts" /></li>
                </ul>

            </div>
            <!--------------------------------換圖結束---------------------------------------------------->




            <div class="conbg">
                <!--------------------------------左邊選單開始---------------------------------------------------->
                <div class="left">
                    <div class="left1">
                        <p><span>DEALERS</span></p>
                        <ul>
                            <asp:Literal ID="LeftMenu" runat="server"></asp:Literal>
                        </ul>
                    </div>
                </div>
                <!--------------------------------左邊選單結束---------------------------------------------------->

                <!--------------------------------右邊選單開始---------------------------------------------------->
                <div id="crumb">
                    <a href="index.aspx">Home</a> >> <a href="#">Dealers </a>>> <a href="#"><span
                        class="on1" id="LabLink" runat="server">USA</span></a>
                </div>
                <div class="right">
                    <div class="right1">
                        <div class="title">
                            <span id="LitTitle" runat="server">USA</span>
                        </div>

                        <!--------------------------------內容開始---------------------------------------------------->
                        <%-- <div class="box2_list">
                            <ul>

                                <li>
                                    <div class="list02">
                                        <ul>
                                            <li class="list02li">
                                                <div>
                                                    <p>
                                                        <img src="Yatchassets/images/dealers001.jpg" />></p>
                                                </div>
                                            </li>
                                            <li><span>Annapolis</span><br />
                                                Noyce Yachts<br />
                                                Contact：Mr. Robert Noyce
                                                <br />
                                                Address：4880 Church Lane Galesville, MD 20765
                                                <br />
                                                TEL：(410)263-3346
                                                <br />
                                                E-mail：Robert@noyceyachts.com
                                                <br />
                                                <a href="http://www.noyceyachts.com" target="_blank">www.noyceyachts.com</a></li>
                                        </ul>
                                    </div>
                                </li>


                                <li>
                                    <div class="list02">
                                        <ul>
                                            <li class="list02li">
                                                <div>
                                                    <p>
                                                        <img src="Yatchassets/images/dealers002.jpg" alt="&quot;&quot;" /></p>
                                                </div>
                                            </li>
                                            <li><span>San Francisco</span><br />
                                                Pacific Yacht Imports<br />
                                                Contact：Mr. Neil Weinberg<br />
                                                Address：Grand Marina 2051 Grand Street# 12 Alameda, CA 94501, USA<br />
                                                TEL：(510)865-2541<br />
                                                FAX：(510)865-2369<br />

                                                <a href="http://www.pacificyachtimports.net" target="_blank">www.pacificyachtimports.net</a></li>
                                        </ul>
                                    </div>
                                </li>

                                <li>
                                    <div class="list02">
                                        <ul>
                                            <li class="list02li">
                                                <div>
                                                    <img src="images/dealers003.jpg" alt="&quot;&quot;" /></div>
                                            </li>
                                            <li><span>Seattle</span><br />
                                                Seattle Yachts<br />
                                                Contact：Ted Griffin<br />
                                                Address：Shilshole Bay Marina 7001 Seaview Ave NW, Suite 150 Seattle
                                                <br />
                                                WA 98117<br />
                                                TEL：(206.789.8044<br />
                                                FAX：(206.789.3976<br />
                                                Cell：(206.819.7137<br />
                                                E-mail：ted@seattleyachts.com<br />
                                                <a href="http://www.seattleyachts.com" target="_blank">www.seattleyachts.com</a><br />
                                            </li>
                                        </ul>
                                    </div>
                                </li>


                                <li>
                                    <div class="list02">
                                        <ul>
                                            <li class="list02li">
                                                <div>
                                                    <img src="Yatchassets/images/dealers004.jpg" alt="&quot;&quot;" /></div>
                                            </li>
                                            <li><span>Seattle</span><br />
                                                Seattle Yachts<br />
                                                Contact：Ted Griffin<br />
                                                Address：Shilshole Bay Marina 7001 Seaview Ave NW, Suite 150 Seattle
                                                <br />
                                                WA 98117<br />
                                                TEL：(206.789.8044<br />
                                                FAX：(206.789.3976<br />
                                                Cell：(206.819.7137<br />
                                                E-mail：ted@seattleyachts.com<br />
                                                <a href="http://www.seattleyachts.com" target="_blank">www.seattleyachts.com</a><br />
                                            </li>
                                        </ul>
                                    </div>
                                </li>


                            </ul>

                           


                        </div>--%>
                        <div class="box2_list">
                            <ul>
                                <asp:Literal ID="DealerList" runat="server"></asp:Literal>
                            </ul>
                            <div class="pagenumber"></div>
                        </div>

                         <div class="pagenumber">| <span>1</span> | <a href="#">2</a> | <a href="#">3</a> | <a href="#">4</a> | <a href="#">5</a> |  <a href="#">Next</a>  <a href="#">LastPage</a></div>
                            <div class="pagenumber1">Items：<span>89</span>  |  Pages：<span>1/9</span></div>

                        <!--------------------------------內容結束------------------------------------------------------>
                    </div>
                </div>

                <!--------------------------------右邊選單結束---------------------------------------------------->
            </div>


            <!--------------------------------落款開始---------------------------------------------------->
            <div class="footer">
                <p class="footerp01">© 1973-2011 Tayana Yachts, Inc. All Rights Reserved</p>
                <div class="footer01">
                    <span>No. 60, Hai Chien Road, Chung Men Li, Lin Yuan District, Kaohsiung City, Taiwan, R.O.C.</span><br />
                    <span>TEL：+886(7)641-2721</span> <span>FAX：+886(7)642-3193</span><span><a href="mailto:tayangco@ms15.hinet.net">E-mail：tayangco@ms15.hinet.net</a>.</span>
                </div>
            </div>
            <!--------------------------------落款結束---------------------------------------------------->

        </div>
    </form>
</body>
</html>
