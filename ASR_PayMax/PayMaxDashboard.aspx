<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="PayMaxDashboard.aspx.cs" Inherits="ASR_PayMax.PayMaxDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<%--<section class="content-header">
        <h1>Dashboard
                               <small>Version 0.1</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Dashboard</li>
        </ol>
    </section>--%>
	<style>
		* {
			box-sizing: border-box;
		}

		.box {
			float: left;
			width: 48%;
			padding: 50px;
			margin-left: 15px;
			border-radius: 25px;
		}

		.clearfix::after {
			content: "";
			clear: both;
			display: table;
		}
		p{
			text-align : center;
			text-size-adjust : inherit;
		    
		}
	</style>
	<div class="card">
		<div class="card-body">

			<asp:UpdatePanel ID="UpdatePanel2" runat="server">
				<ContentTemplate>
					<%--<br /> <br /> <br /> <br /> <br /> <br />
                    <br /> <br /> <br /> <br /> <br /> <br />
                    <br /> <br /> <br /> <br /> <br /> <br />
                    <br /> <br /> <br /> <br /> <br /> <br />
                    <br /> <br /> <br /> <br /> <br /> <br />
                    <br /> <br /> <br /> <br /> <br /> <br />
                    <br /> <br /> <br /> <br /> <br /> <br />
                    <br /> <br /> <br /> <br /> <br /> <br />
                    <br /> <br /> <br /> <br /> <br /> <br />--%>
					<div class="clearfix">
						<div class="box" style="background-color: #bbb" onclick="location.href='http://localhost:52737/Registrations/Users.aspx'">
							<p><a> User Registration</a></p>
						</div>
						<div class="box" style="background-color: #6AB187">
							<p>Some text inside the box.</p>
						</div>
						<div class="box" style="background-color: #D32D41">
							<p>Some text inside the box.</p>
						</div>
						<div class="box" style="background-color: #4CB5F5">
							<p>Some text inside the box.</p>
						</div>
						<div class="box" style="background-color: #B3C100">
							<p>Some text inside the box.</p>
						</div>
						<div class="box" style="background-color: #DBAE58">
							<p>Some text inside the box.</p>
						</div>
						
					</div>
				</ContentTemplate>
			</asp:UpdatePanel>
		</div>
	</div>

	<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
             <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Role Name"></asp:Label>
                                <asp:TextBox runat="server" ID="txtRoleName" CssClass="form-control RoundText"></asp:TextBox>
                                <input id="hddRoleID" type="hidden" runat="server" value="0" />
                            </div>
                        </div>
                    </div>
            <asp:Panel ID="pnlDynamic" runat="server" ClientIDMode="Static"></asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
	<%--<div class="row">
        <div class="col-xs-12">
            <div class="panel">
                <div class="panel-header">
                    <div class="panel-title">
                        <h3><b>&nbsp;&nbsp;Monthly Recap Report</b></h3>
                    </div>

                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-8">
                                <p class="text-center">
                                    <strong>Sales: 1 Jan, 2014 - 30 Jul, 2014</strong>
                                </p>

                                <div class="chart">
                                    <!-- Sales Chart Canvas -->
                                    <canvas id="salesChart" style="height: 180px;"></canvas>
                                </div>
                                <!-- /.chart-responsive -->
                            </div>
                            <!-- /.col -->
                            <div class="col-md-4">
                                <p class="text-center">
                                    <strong>Goal Completion</strong>
                                </p>

                                <div class="progress-group">
                                    <span class="progress-text">Add Products to Cart</span>
                                    <span class="progress-number"><b>160</b>/200</span>

                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-aqua" style="width: 80%"></div>
                                    </div>
                                </div>
                                <!-- /.progress-group -->
                                <div class="progress-group">
                                    <span class="progress-text">Complete Purchase</span>
                                    <span class="progress-number"><b>310</b>/400</span>

                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-red" style="width: 80%"></div>
                                    </div>
                                </div>
                                <!-- /.progress-group -->
                                <div class="progress-group">
                                    <span class="progress-text">Visit Premium Page</span>
                                    <span class="progress-number"><b>480</b>/800</span>

                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-green" style="width: 80%"></div>
                                    </div>
                                </div>
                                <!-- /.progress-group -->
                                <div class="progress-group">
                                    <span class="progress-text">Send Inquiries</span>
                                    <span class="progress-number"><b>250</b>/500</span>

                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-yellow" style="width: 80%"></div>
                                    </div>
                                </div>
                                <div class="progress-group">
                                    <span class="progress-text">Add Products to Cart</span>
                                    <span class="progress-number"><b>160</b>/200</span>

                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-aqua" style="width: 80%"></div>
                                    </div>
                                </div>
                                <!-- /.progress-group -->
                                <div class="progress-group">
                                    <span class="progress-text">Complete Purchase</span>
                                    <span class="progress-number"><b>310</b>/400</span>

                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-red" style="width: 80%"></div>
                                    </div>
                                </div>
                                <!-- /.progress-group -->
                                <div class="progress-group">
                                    <span class="progress-text">Visit Premium Page</span>
                                    <span class="progress-number"><b>480</b>/800</span>

                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-green" style="width: 80%"></div>
                                    </div>
                                </div>
                                <!-- /.progress-group -->
                                <div class="progress-group">
                                    <span class="progress-text">Send Inquiries</span>
                                    <span class="progress-number"><b>250</b>/500</span>

                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-yellow" style="width: 80%"></div>
                                    </div>
                                </div>
                                <div class="progress-group">
                                    <span class="progress-text">Add Products to Cart</span>
                                    <span class="progress-number"><b>160</b>/200</span>

                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-aqua" style="width: 80%"></div>
                                    </div>
                                </div>
                                <!-- /.progress-group -->
                                <div class="progress-group">
                                    <span class="progress-text">Complete Purchase</span>
                                    <span class="progress-number"><b>310</b>/400</span>

                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-red" style="width: 80%"></div>
                                    </div>
                                </div>
                                <!-- /.progress-group -->
                                <div class="progress-group">
                                    <span class="progress-text">Visit Premium Page</span>
                                    <span class="progress-number"><b>480</b>/800</span>

                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-green" style="width: 80%"></div>
                                    </div>
                                </div>
                                <!-- /.progress-group -->
                                <div class="progress-group">
                                    <span class="progress-text">Send Inquiries</span>
                                    <span class="progress-number"><b>250</b>/500</span>

                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-yellow" style="width: 80%"></div>
                                    </div>
                                </div>
                                <!-- /.progress-group -->
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>
