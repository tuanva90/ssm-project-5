<%@ Page Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="DiemTKCuoiKy.aspx.cs" Inherits="Admin_DiemTKCuoiKy" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    f.<style type="text/css">
        .style18
        {
            font-size: 22pt;
            font-weight: bold;
            color: #0000FF;
        }
        .style1
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
        </style><p style="text-align: center">
        &nbsp;</p>
             <p class="style18" style="text-align: center; height: 4px;" 
        __designer:mapid="8e">
                 Điểm từng lớp theo môn học</p>
    <p class="style18" style="text-align: center; height: 4px;" 
        __designer:mapid="8e">
                 &nbsp;</p>
    <p class="style18" style="text-align: center; height: 4px;" 
        __designer:mapid="8e">
                 &nbsp;</p>
            <p>
                                <asp:Label ID="lbldiemcuoinam" runat="server" Text="Năm học :"></asp:Label>
                                <asp:DropDownList ID="ddnamhoc" runat="server" Height="25px" 
                                    AutoPostBack="True" DataTextField="Năm học" 
                                    DataValueField="Mã năm" 
                                    Width="115px" onselectedindexchanged="ddnamhoc_SelectedIndexChanged">
                                </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;</p>
    <p>
                <asp:Label ID="Label4" runat="server" Text=" "></asp:Label>
                <asp:Label ID="Label5" runat="server" Text="Lớp : "></asp:Label>
                <asp:DropDownList ID="ddllop" runat="server" AutoPostBack="True" 
                    DataTextField="Tên lớp" DataValueField="Mã lớp" 
                    onselectedindexchanged="ddllop_SelectedIndexChanged">
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
                </p>
<p>
                <asp:Label ID="lblinfor" runat="server" ForeColor="Blue"></asp:Label>
                </p>
    <div align = center>
                    <asp:GridView ID="gvtkdiem" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" CssClass="style13" ShowFooter="True" 
                        Width="800px" HorizontalAlign="Center" 
                        onselectedindexchanged="gvtkdiem_SelectedIndexChanged" ForeColor="#333333" 
                        onpageindexchanging="gvtkdiem_PageIndexChanging" GridLines="Horizontal">
                        <RowStyle BackColor="#E3EAEB" />
                        <Columns>
                            <asp:TemplateField HeaderText="Mã học sinh" InsertVisible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblmahs" runat="server" CssClass="style9" 
                                        Text='<%# Eval("Mã HS") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <br />
                                </FooterTemplate>
                                <ControlStyle CssClass="style9" Width="110px" />
                                <FooterStyle CssClass="style9" />
                                <HeaderStyle CssClass="style9" Width="100px" />
                                <ItemStyle CssClass="style1" Width="110px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Họ tên">
                                <ItemTemplate>
                                    <asp:Label ID="lblhoten" runat="server" CssClass="style9" 
                                        Text='<%# Eval("Họ tên") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <br />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    &nbsp; &nbsp;
                                </FooterTemplate>
                                <ControlStyle CssClass="style9" Width="200px" />
                                <FooterStyle CssClass="style9" />
                                <HeaderStyle CssClass="style9" Width="200px" />
                                <ItemStyle CssClass="style1" Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Điểm CK I">
                                <ItemTemplate>
                                    <asp:Label ID="lbldiemck1" runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="lbtntinhdiemck1" runat="server" 
                                        onclick="lbtntinhdiemck1_Click">Tính ĐCK I</asp:LinkButton>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <HeaderStyle Width="100px" />
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HK CK I">
                                <FooterTemplate>
                                    <asp:LinkButton ID="lbtnluuhkk1" runat="server" onclick="lbtnluuhkk1_Click">Lưu 
                                    HK kỳ I</asp:LinkButton>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txthkck1" runat="server" Text='<%# Eval("HK CK") %>' 
                                        Width="90px"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="70px" />
                                <ItemStyle CssClass="style1" Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Điểm CK II">
                                <ItemTemplate>
                                    <asp:Label ID="lbldiemck2" runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="lbtntinhdiemck2" runat="server" 
                                        onclick="lbtntinhdiemck2_Click">Tính ĐCK II</asp:LinkButton>
                                </FooterTemplate>
                                <ControlStyle Width="100px" />
                                <HeaderStyle Width="100px" />
                                <ItemStyle Width="100px" CssClass="style1" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HK CK II">
                                <FooterTemplate>
                                    <asp:LinkButton ID="btnluuhkk2" runat="server" onclick="btnluuhkk2_Click">Lưu HK 
                                    kỳ II</asp:LinkButton>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txthkck2" runat="server" Width="90px"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="70px" />
                                <ItemStyle CssClass="style1" Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Điểm CNam">
                                <FooterTemplate>
                                    <asp:LinkButton ID="lbltinhdiemcuoinam" runat="server" 
                                        onclick="lbltinhdiemcuoinam_Click">Tính Điểm CN</asp:LinkButton>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbldiemcuoinam" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <HeaderStyle Width="100px" />
                                <ItemStyle Width="100px" CssClass="style1" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HK CNam">
                                <FooterTemplate>
                                    <asp:LinkButton ID="lbtnluuhkcuoinam" runat="server" 
                                        onclick="lbtnluuhkcuoinam_Click">Lưu HK cuối năm</asp:LinkButton>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txthkcuoinam" runat="server" Width="90px"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="70px" />
                                <ItemStyle CssClass="style1" Width="70px" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <EmptyDataTemplate>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </EmptyDataTemplate>
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Center" />
                        <EditRowStyle HorizontalAlign="Center" BackColor="#7C6F57" />
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










