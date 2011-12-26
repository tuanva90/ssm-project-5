<%@ Page Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="QuanLyKhoiLop_MonHoc.aspx.cs" Inherits="Admin_QuanLyKhoiLop_MonHoc" Title="Untitled Page" %>



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
        }
        </style>
    <p style="text-align: center">
        &nbsp;</p>
             <p class="style18" style="text-align: center; height: 4px;" 
        __designer:mapid="8e">
                 Quản lý khối lớp-môn học</p>
            <p>
                &nbsp;</p>
    <p>
                                <asp:Label ID="Label3" runat="server" Text="Năm học :"></asp:Label>
&nbsp;
                                <asp:DropDownList ID="ddnamhoc" runat="server" Height="25px" 
                                    AutoPostBack="True" DataTextField="Năm học" 
                                    DataValueField="Mã năm" 
                                    Width="100px" onselectedindexchanged="ddnamhoc_SelectedIndexChanged">
                                </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Khối lớp :"></asp:Label>
&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlkhoilop" runat="server" 
                                    DataTextField="Tên khối" DataValueField="Mã khối" 
                                    onselectedindexchanged="ddlkhoilop_SelectedIndexChanged" 
                                    AutoPostBack="True">
                                </asp:DropDownList>
    </p>
    <div align = center>
                    <asp:GridView ID="gvphanmon" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" CssClass="style13" 
                        ForeColor="#333333" GridLines="None" ShowFooter="True" 
                        Width="600px" HorizontalAlign="Center" 
                        onpageindexchanging="gvphanmon_PageIndexChanging" 
                        onselectedindexchanged="gvphanmon_SelectedIndexChanged">
                        <RowStyle BackColor="#E3EAEB" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ckchon" runat="server" AutoPostBack="True" 
                                        oncheckedchanged="ckbcheck_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mã môn">
                                <ItemTemplate>
                                    <asp:Label ID="lblmamon" runat="server" Text='<%# Eval("Mã môn") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Môn học">
                                <ItemTemplate>
                                    <asp:Label ID="lblmonhoc" runat="server" Text='<%# Eval("Tên Môn") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hệ số">
                                <ItemTemplate>
                                    <asp:Label ID="lblheso" runat="server" Text='<%# Eval("Hệ số") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
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
                 </br>
                </br>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>










