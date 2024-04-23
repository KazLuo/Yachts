﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contect.aspx.cs" Inherits="Yacht.WebForm2" %>

<%@ Register Assembly="Recaptcha.Web" Namespace="Recaptcha.Web.UI.Controls" TagPrefix="cc1" %>


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
                <p><a href="index.aspx">Home</a></p>
            </div>

            <!--------------------------------選單開始---------------------------------------------------->
      <%--      <div class="menu">
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
                <img src="Yatchassets/images/contact.jpg" alt="&quot;&quot;" width="967" height="371" />
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
                        <p><span>CONTACT</span></p>
                        <ul>
                            <li><a href="#">contacts</a></li>
                        </ul>



                    </div>




                </div>







                <!--------------------------------左邊選單結束---------------------------------------------------->

                <!--------------------------------右邊選單開始---------------------------------------------------->
                <div id="crumb"><a href="#">Home</a> >> <a href="#"><span class="on1">Contact</span></a></div>
                <div class="right">
                    <div class="right1">
                        <div class="title"><span>Contact</span></div>

                        <!--------------------------------內容開始---------------------------------------------------->
                        <!--表單-->
                        <div class="from01">
                            <p>
                                Please Enter your contact information<span class="span01">*Required</span>
                            </p>
                            <br />
                            <table>
                                <tr>
                                    <td class="from01td01">Name :</td>
                                    <td><span>*</span><asp:TextBox runat="server" name="Name" type="text" ID="Name" class="{validate:{required:true, messages:{required:'Required'}}}" Style="width: 250px;" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required!')" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <%-- <tr>
            <td class="from01td01">Email :</td>
            <td><span>*</span><asp:TextBox runat="server" name="Email" type="text" ID="Email" class="{validate:{required:true, email:true, messages:{required:'Required', email:'Please check the E-mail format is correct'}}}" Style="width: 250px;" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required!')" MaxLength="50"></asp:TextBox>
            </td>
        </tr>--%>
                                <tr>
                                    <td class="from01td01">Email :</td>
                                    <td>
                                        <span>*</span>
                                        <asp:TextBox runat="server" ID="Email" CssClass="emailInput" Style="width: 250px;" MaxLength="50"></asp:TextBox>
                                        <asp:RegularExpressionValidator runat="server" ControlToValidate="Email" CssClass="emailValidator"
                                            ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
                                            ErrorMessage="Please enter a valid email address" Display="Dynamic" ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="from01td01">Phone :</td>
                                    <td><span>*</span><asp:TextBox runat="server" name="Phone" type="text" ID="Phone" class="{validate:{required:true, messages:{required:'Required'}}}" Style="width: 250px;" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('Required!')" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="from01td01">Country :</td>
                                    <td><span>*</span>
                                        <asp:DropDownList name="Country" ID="Country" runat="server" DataTextField="country" DataSourceID="SqlDataSource1" DataValueField="country"></asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:YachtConnectionString %>" SelectCommand="SELECT Country.country FROM [Dealers] Join Country ON Dealers.country = Country.id"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><span>*</span>Brochure of interest *Which Brochure would you like to view?</td>
                                </tr>
                                <tr>
                                    <td class="from01td01"></td>
                                    <td>
                                        <asp:DropDownList name="Yachts" ID="Yachts" runat="server" DataTextField="yachtName" DataValueField="yachtName" DataSourceID="SqlDataSource2"></asp:DropDownList>
                                        <br />
                                       <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:YachtConnectionString %>" SelectCommand="SELECT CONCAT(model, ' ', type) as yachtName FROM [Yachts]"></asp:SqlDataSource>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="from01td01">Comments:</td>
                                    <td>
                                        <asp:TextBox runat="server" TextMode="MultiLine" name="Comments" Rows="2" cols="20" ID="Comments" Style="height: 150px; width: 330px;" MaxLength="500"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="from01td01"></td>
                                    <td class="f_right">
                                        <!-- Render recaptcha API script -->
                                        <cc1:RecaptchaApiScript ID="RecaptchaApiScript1" runat="server" />
                                        <!-- Render recaptcha widget -->
                                        <cc1:RecaptchaWidget ID="RecaptchaWidget1" runat="server" />
                                        <asp:Label ID="lblMessage" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="from01td01"></td>
                                    <td class="f_right">
                                        <asp:ImageButton runat="server" type="image" name="ImageButton1" ID="ImageButton1" src="Yatchassets/images/buttom03.gif" Style="border-width: 0px;" Height="25px" OnClick="ImageButton1_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!--表單-->

                        <div class="box1">
                            <span class="span02">Contact with us</span><br />
                            Thanks for your enjoying our web site as an introduction to the Tayana world and our range of yachts.
As all the designs in our range are semi-custom built, we are glad to offer a personal service to all our potential customers. 
If you have any questions about our yachts or would like to take your interest a stage further, please feel free to contact us.
                        </div>

                        <div class="list03">
                            <p>
                                <span>TAYANA HEAD OFFICE</span><br />
                                NO.60 Haichien Rd. Chungmen Village Linyuan Kaohsiung Hsien 832 Taiwan R.O.C<br />
                                tel. +886(7)641 2422<br />
                                fax. +886(7)642 3193<br />
                                info@tayanaworld.com<br />
                            </p>
                        </div>


                        <div class="list03">
                            <p>
                                <span>SALES DEPT.</span><br />
                                +886(7)641 2422  ATTEN. Mr.Basil Lin<br />
                                <br />
                            </p>
                        </div>

                        <div class="box4">
                            <h4>Location</h4>
                            <p>
                                <iframe width="695" height="518" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.com/maps?f=d&amp;source=s_d&amp;saddr=%E5%8F%B0%E7%81%A3%E9%AB%98%E9%9B%84%E5%B8%82%E5%B0%8F%E6%B8%AF%E5%8D%80%E4%B8%AD%E5%B1%B1%E5%9B%9B%E8%B7%AF%E9%AB%98%E9%9B%84%E5%B0%8F%E6%B8%AF%E6%A9%9F%E5%A0%B4&amp;daddr=%E5%8F%B0%E7%81%A3%E9%AB%98%E9%9B%84%E5%B8%82%E6%9E%97%E5%9C%92%E5%8D%80%E4%B8%AD%E9%96%80%E6%9D%91%E6%B5%B7%E5%A2%98%E8%B7%AF%EF%BC%96%EF%BC%90%E8%99%9F&amp;hl=zh-en&amp;geocode=FRthWAEdwlwsByGxkQ4S1t-ckinNS9aM0xxuNDELEXJZh6Soqg%3BFRRmVwEdMKssBym5azbzl-JxNDGd62mwtzGaDw&amp;aq=0&amp;oq=%E9%AB%98%E9%9B%84%E5%B0%8F%E6%B8%AF%E6%A9%9F&amp;sll=22.50498,120.36792&amp;sspn=0.008356,0.016512&amp;g=%E5%8F%B0%E7%81%A3%E9%AB%98%E9%9B%84%E5%B8%82%E6%9E%97%E5%9C%92%E5%8D%80%E4%B8%AD%E9%96%80%E6%9D%91%E6%B5%B7%E5%A2%98%E8%B7%AF%EF%BC%96%EF%BC%90%E8%99%9F&amp;mra=ls&amp;ie=UTF8&amp;t=m&amp;ll=22.537135,120.360718&amp;spn=0.08213,0.119133&amp;z=13&amp;output=embed"></iframe>
                            </p>


                        </div>




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
