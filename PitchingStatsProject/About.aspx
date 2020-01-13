<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PitchingStatsProject.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Padres Pitching Stats Project.</h3>
    <p>Components used for this project.</p>
    <asp:Image ID="Image1"  ImageURL="~/Images/setUp.jpg" runat="server"/>
</asp:Content>
