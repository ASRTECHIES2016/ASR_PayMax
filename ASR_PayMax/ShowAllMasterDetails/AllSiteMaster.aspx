<%@ Page Title="All Site Master" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="AllSiteMaster.aspx.cs" Inherits="ASR_PayMax.ShowAllMasterDetails.AllSiteMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">All Site Master</li>
        </ol>
    </section>
    <div class="card">
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">&nbsp;&nbsp;User's Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                hgfh
                    </div></div></div>


                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
</asp:Content>
