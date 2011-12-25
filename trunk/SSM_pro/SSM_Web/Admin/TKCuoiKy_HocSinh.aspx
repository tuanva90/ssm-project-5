<%@ Page Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="TKCuoiKy_HocSinh.aspx.cs" Inherits="Admin_TKCuoiKy_HocSinh" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .style18
        {
            font-size: 22pt;
            font-weight: bold;
            color: #0000FF;
        }
        .style13
        {
        	text-align:center;
        }
                                             
.dxeButtonEdit
{
    background-color: white;
    border: solid 1px #9F9F9F;
    width: 170px;
}
        
.dxeButtonEdit
{
    background-color: white;
    border: solid 1px #9F9F9F;
    width: 170px;
}

.dxeEditArea 
{
	font-family: Tahoma;
	font-size: 9pt;
	border: 1px solid #A0A0A0;
}

.dxeEditArea 
{
	font-family: Tahoma;
	font-size: 9pt;
	border: 1px solid #A0A0A0;
}
.dxeButtonEditButton,
.dxeSpinIncButton, .dxeSpinDecButton, .dxeSpinLargeIncButton, .dxeSpinLargeDecButton
{
    padding: 0px 2px 0px 3px;
	    background-repeat: repeat-x;
    background-position: top;    
    background-color: #e6e6e6;
}
.dxeButtonEditButton, .dxeCalendarButton,
.dxeSpinIncButton, .dxeSpinDecButton,
.dxeSpinLargeIncButton, .dxeSpinLargeDecButton
{	
	vertical-align: middle;
	border: solid 1px #7f7f7f;
	cursor: pointer;
	cursor: hand;
} 
.dxeButtonEditButton
{	
	vertical-align: middle;
	border: solid 1px #7f7f7f;
	cursor: pointer;
	cursor: hand;
} 
        .dxeButtonEditButton
{
    padding: 0px 2px 0px 3px;
	    background-repeat: repeat-x;
    background-position: top;    
    background-color: #e6e6e6;
}
        .style13
        {
           width: 700px;     
           font-size:12pt;
            margin-top: 0px;
        }
        </style>
    <p style="text-align: center">
        &nbsp;</p>
             <p class="style18" style="text-align: center; height: 4px;" 
        __designer:mapid="8e">
                 Kết quả học tập</p>
    <p class="style18" style="text-align: center; height: 4px;" 
        __designer:mapid="8e">
                 &nbsp;</p>
            <p>
                                <asp:Label ID="Label2" runat="server" Text="Năm học :"></asp:Label>
                                <asp:DropDownList ID="ddnamhoc" runat="server" Height="25px" 
                                    AutoPostBack="True" DataTextField="Năm học" 
                                    DataValueField="Mã năm" 
                                    Width="115px" onselectedindexchanged="ddnamhoc_SelectedIndexChanged">
                                </asp:DropDownList>
    &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Học kỳ :"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlhk" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlhk_SelectedIndexChanged" style="height: 22px">
                                    <asp:ListItem Value="I">Học kỳ I</asp:ListItem>
                                    <asp:ListItem Value="II">Học kỳ II</asp:ListItem>
                                    <asp:ListItem Value="CN">Cả năm</asp:ListItem>
                </asp:DropDownList>
&nbsp;</p>
    <p>
                                <asp:Label ID="lblmahs" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lbltenhs" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lbllop" runat="server"></asp:Label>
    </p>
    <p>
                                <asp:Label ID="lblhanhkiem" runat="server"></asp:Label>
    </p>
    <div align = center>
                    <asp:GridView ID="gvtongket" runat="server" AllowPaging="True" 
                        CellPadding="4" CssClass="style13" 
                        ForeColor="#333333" GridLines="None" ShowFooter="True" 
                        Width="700px" HorizontalAlign="Center" 
                        onpageindexchanging="gvtongket_PageIndexChanging">
                        <RowStyle BackColor="#E3EAEB" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <EmptyDataTemplate>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </EmptyDataTemplate>
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Center" />
                        <EditRowStyle BackColor="#7C6F57" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                 </div>
    <p>
                                &nbsp;</p>
                 </br>
                </br>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>












