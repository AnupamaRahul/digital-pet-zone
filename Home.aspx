<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <!-- Start slides -->
    <div id="slides" class="cover-slides">
        <ul class="slides-container">
            <li class="text-center">
                <img src="images/dog.jpg" alt="">
               
            </li> 
              <li class="text-center">
                <img src="images/pets-1.png" />" />" alt="">
               
            </li>

             <li class="text-center">
               <img src="images/pexels-photo-127027.jpeg" />" alt="">
                
           </li>

           

            <li class="text-center">
                <img src="images/pexels-photo-2883510.jpeg" />" alt="">
               
            </li>

             <li class="text-center">
                <img src="images/pexels-photo-460775.jpeg" />" alt="">
               
            </li>
        </ul>
        <div class="slides-navigation">
            <a href="#" class="next"><i class="fa fa-angle-right" aria-hidden="true"></i></a>
            <a href="#" class="prev"><i class="fa fa-angle-left" aria-hidden="true"></i></a>
        </div>
    </div>
    <!-- End slides -->


</asp:Content>

