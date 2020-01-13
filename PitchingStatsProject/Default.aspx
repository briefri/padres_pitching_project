<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PitchingStatsProject._Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Brie's Pitching with Padres</h1>
        <p class="lead">Welcome, come take a swing at my pitching stats!</p>
        <p><a href="https://aws.amazon.com/elasticbeanstalk/" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Average Pitch Speed</h2>
            <asp:Chart ID="Chart1" runat="server">
                <Series>
                    <asp:Series Name="PitchSpeed"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
        <div class="col-md-4">
            <h2>Pitch Type</h2>
            <asp:Chart ID="Chart2" runat="server">
                <Series>
                    <asp:Series Name="Series1" Label="Splitter" XValueMember ="pitcher" YValueMembers ="Splitter"></asp:Series>
                    <asp:Series Name="Series2" Label="Fastball" XValueMember ="pitcher" YValueMembers ="Fastball"></asp:Series>
                    <asp:Series Name="Series3" Label="Sinker" XValueMember ="pitcher" YValueMembers ="Sinker"></asp:Series>
                    <asp:Series Name="Series4" Label="ChangeUp" XValueMember ="pitcher" YValueMembers ="ChangeUp"></asp:Series>
                    <asp:Series Name="Series5" Label="Cutter" XValueMember ="pitcher" YValueMembers ="Cutter"></asp:Series>
                    <asp:Series Name="Series7" Label="Curveball" XValueMember ="pitcher" YValueMembers ="Curveball"></asp:Series>
                    <asp:Series Name="Series8" Label="Slider" XValueMember ="pitcher" YValueMembers ="Slider"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
        <div class="col-md-4">
            <h2>Stance Comparison</h2>
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>Fastball</asp:ListItem>
                <asp:ListItem>Sinker</asp:ListItem>
                <asp:ListItem>ChangeUp</asp:ListItem>
                <asp:ListItem>Cutter</asp:ListItem>
                <asp:ListItem>Curveball</asp:ListItem>
                <asp:ListItem>Slider</asp:ListItem>
                <asp:ListItem>Splitter</asp:ListItem>
            </asp:DropDownList>
            <asp:Chart ID="Chart3" runat="server">
                <Series>
                    <asp:Series Name="Series1" Label="Stretch" XValueMember ="pitcher" YValueMembers ="Stretch"></asp:Series>
                    <asp:Series Name="Series2" Label="Windup" XValueMember ="pitcher" YValueMembers ="Windup"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <h2>Play Results by Pitch Type</h2>
            <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>Single</asp:ListItem>
                <asp:ListItem>Double</asp:ListItem>
                <asp:ListItem>Triple</asp:ListItem>
                <asp:ListItem>HomeRun</asp:ListItem>
            </asp:DropDownList>
            <asp:Chart ID="Chart4" runat="server">
                <Series>
                    <asp:Series Name="Series1" Label="Splitter" XValueMember ="pitcher" YValueMembers ="Splitter"></asp:Series>
                    <asp:Series Name="Series2" Label="Fastball" XValueMember ="pitcher" YValueMembers ="Fastball"></asp:Series>
                    <asp:Series Name="Series3" Label="Sinker" XValueMember ="pitcher" YValueMembers ="Sinker"></asp:Series>
                    <asp:Series Name="Series4" Label="ChangeUp" XValueMember ="pitcher" YValueMembers ="ChangeUp"></asp:Series>
                    <asp:Series Name="Series5" Label="Cutter" XValueMember ="pitcher" YValueMembers ="Cutter"></asp:Series>
                    <asp:Series Name="Series7" Label="Curveball" XValueMember ="pitcher" YValueMembers ="Curveball"></asp:Series>
                    <asp:Series Name="Series8" Label="Slider" XValueMember ="pitcher" YValueMembers ="Slider"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
        <div class="col-md-4">
        <h2>Pitch Call by Pitch Type</h2>
        <asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>StrikeCalled</asp:ListItem>
            <asp:ListItem>BallCalled</asp:ListItem>
        </asp:DropDownList>
        <asp:Chart ID="Chart5" runat="server">
            <Series>
                <asp:Series Name="Series1" Label="Splitter" XValueMember ="pitcher" YValueMembers ="Splitter"></asp:Series>
                <asp:Series Name="Series2" Label="Fastball" XValueMember ="pitcher" YValueMembers ="Fastball"></asp:Series>
                <asp:Series Name="Series3" Label="Sinker" XValueMember ="pitcher" YValueMembers ="Sinker"></asp:Series>
                <asp:Series Name="Series4" Label="ChangeUp" XValueMember ="pitcher" YValueMembers ="ChangeUp"></asp:Series>
                <asp:Series Name="Series5" Label="Cutter" XValueMember ="pitcher" YValueMembers ="Cutter"></asp:Series>
                <asp:Series Name="Series7" Label="Curveball" XValueMember ="pitcher" YValueMembers ="Curveball"></asp:Series>
                <asp:Series Name="Series8" Label="Slider" XValueMember ="pitcher" YValueMembers ="Slider"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
        <div class="col-md-4">
        <h2>Spin Rate by Pitch Type</h2>
        <asp:Chart ID="Chart6" runat="server">
            <Series>
                <asp:Series Name="Series1" Label="Splitter" XValueMember ="pitcher" YValueMembers ="Splitter"></asp:Series>
                <asp:Series Name="Series2" Label="Fastball" XValueMember ="pitcher" YValueMembers ="Fastball"></asp:Series>
                <asp:Series Name="Series3" Label="Sinker" XValueMember ="pitcher" YValueMembers ="Sinker"></asp:Series>
                <asp:Series Name="Series4" Label="ChangeUp" XValueMember ="pitcher" YValueMembers ="ChangeUp"></asp:Series>
                <asp:Series Name="Series5" Label="Cutter" XValueMember ="pitcher" YValueMembers ="Cutter"></asp:Series>
                <asp:Series Name="Series7" Label="Curveball" XValueMember ="pitcher" YValueMembers ="Curveball"></asp:Series>
                <asp:Series Name="Series8" Label="Slider" XValueMember ="pitcher" YValueMembers ="Slider"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        </div>
    </div>
    <div class="jumbotron">
        <h1>View All Pitching Data</h1>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="view full database" Width="179px" />
        <asp:GridView ID="GridView1" runat="server" Font-Size="Small"></asp:GridView>
    </div>
</asp:Content>
