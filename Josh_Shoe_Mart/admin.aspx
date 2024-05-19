<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Josh_Shoe_Mart.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Josh  Shop - Product Listing Page</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="apple-touch-icon" href="assets/img/apple-icon.png">
    <link rel="shortcut icon" type="image/x-icon" href="assets/img/favicon.ico">

    <link rel="stylesheet" href="assets/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/css/templatemo.css">
    <link rel="stylesheet" href="assets/css/custom.css">

    <!-- Load fonts style after rendering the layout styles -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;200;300;400;500;700;900&display=swap">
    <link rel="stylesheet" href="assets/css/fontawesome.min.css">

</head>
<body>
    <!-- Start Top Nav -->
    <nav class="navbar navbar-expand-lg bg-dark navbar-light d-none d-lg-block" id="templatemo_nav_top">
        <div class="container text-light">
            <div class="w-100 d-flex justify-content-between">
                <div>
                    <i class="fa fa-envelope mx-2"></i>
                    <a class="navbar-sm-brand text-light text-decoration-none" href="mailto:info@company.com">info@company.com</a>
                    <i class="fa fa-phone mx-2"></i>
                    <a class="navbar-sm-brand text-light text-decoration-none" href="tel:010-020-0340">010-020-0340</a>
                </div>
                <div>
                    <a class="text-light" href="https://fb.com/templatemo" target="_blank" rel="sponsored"><i class="fab fa-facebook-f fa-sm fa-fw me-2"></i></a>
                    <a class="text-light" href="https://www.instagram.com/" target="_blank"><i class="fab fa-instagram fa-sm fa-fw me-2"></i></a>
                    <a class="text-light" href="https://twitter.com/" target="_blank"><i class="fab fa-twitter fa-sm fa-fw me-2"></i></a>
                    <a class="text-light" href="https://www.linkedin.com/" target="_blank"><i class="fab fa-linkedin fa-sm fa-fw"></i></a>
                </div>
            </div>
        </div>
    </nav>
    <!-- Close Top Nav -->


    <!-- Header -->
    <nav class="navbar navbar-expand-lg navbar-light shadow">
        <div class="container d-flex justify-content-between align-items-center">

            <a class="navbar-brand text-success logo h1 align-self-center" href="index.aspx">
                Josh 
            </a>

            <button class="navbar-toggler border-0" type="button" data-bs-toggle="collapse" data-bs-target="#templatemo_main_nav" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="align-self-center collapse navbar-collapse flex-fill  d-lg-flex justify-content-lg-between" id="templatemo_main_nav">
                <div class="flex-fill">
                    <ul class="nav navbar-nav d-flex justify-content-between mx-lg-auto">
                        <li class="nav-item">
                            <a class="nav-link" href="index.aspx">Home</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="about.aspx">About</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="shop.aspx">Shop</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="login.aspx">SignUp/Login</a>
                        </li>
                    </ul>
                </div>
                <div class="navbar align-self-center d-flex">
                    <div class="d-lg-none flex-sm-fill mt-3 mb-4 col-7 col-sm-auto pr-3">
                        <div class="input-group">
                            <input type="text" class="form-control" id="inputMobileSearch" placeholder="Search ...">
                            <div class="input-group-text">
                                <i class="fa fa-fw fa-search"></i>
                            </div>
                        </div>
                    </div>
                    <a class="nav-icon d-none d-lg-inline" href="#" data-bs-toggle="modal" data-bs-target="#templatemo_search">
                        <i class="fa fa-fw fa-search text-dark mr-2"></i>
                    </a>
                    <a class="nav-icon position-relative text-decoration-none" href="#">
                        <i class="fa fa-fw fa-cart-arrow-down text-dark mr-1"></i>
                        <span class="position-absolute top-0 left-100 translate-middle badge rounded-pill bg-light text-dark">7</span>
                    </a>
                    <a class="nav-icon position-relative text-decoration-none" href="#">
                        <i class="fa fa-fw fa-user text-dark mr-3"></i>
                        <span class="position-absolute top-0 left-100 translate-middle badge rounded-pill bg-light text-dark">+99</span>
                    </a>
                </div>
            </div>

        </div>
    </nav>
    <!-- Close Header -->

  
 <div class="container-fluid"> <!-- container start -->
    <!-- Left Section -->
          <form runat="server">
     <div class="row"> <!-- row start -->

      <div class="col-lg-1" style="background-color:beige;"><!-- collomn 1 -->
          <asp:Button ID="btn_edit" Style="margin-top: 6px" Width="100px" class="btn btn-warning" runat="server" Text="Edit" OnClick="btn_edit_Click1" />
      </div>
 
      <!-- add product  Section -->
      <div class="col-lg-4" style="background-color: #e0e0e0;">
    
   <h2>Add Product</h2>
          <h5><span><asp:Label ID="Productadded" Style="color:chartreuse" runat="server" Text=""></asp:Label></span></h5> 

    <div class="mb-3">
        <label for="disabledTextInput" class="form-label">Product Name</label>
        <asp:TextBox ID="txt_ProductName"  class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label for="disabledTextInput" class="form-label">Description</label>
        <asp:TextBox ID="txt_Description" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="mb-3">
      <label for="disabledSelect" class="form-label">Brand</label>
            <asp:DropDownList ID="list_Brand" runat="server" CssClass="form-control">
                <asp:ListItem Text="-- Select --" Value=""></asp:ListItem>
                <asp:ListItem Text="Puma" Value="puma"></asp:ListItem>
                <asp:ListItem Text="Nike" Value="nike"></asp:ListItem>
                <asp:ListItem Text="Reebook" Value="reebook"></asp:ListItem>
                <asp:ListItem Text="Crocs" Value="crocs"></asp:ListItem>
                <asp:ListItem Text="Adidas" Value="adidas"></asp:ListItem>
                <asp:ListItem Text="Levis" Value="levis"></asp:ListItem>
                <asp:ListItem Text="H&M" Value="h&m"></asp:ListItem>             
            </asp:DropDownList>
    </div>

    <div class="mb-3">
            <label for="disabledSelect" class="form-label">Catagory</label>
            <asp:DropDownList ID="list_Catagory" runat="server" CssClass="form-control">
                <asp:ListItem Text="-- Select --" Value=""></asp:ListItem>
                <asp:ListItem Text="Sports" Value="sports"></asp:ListItem>
                <asp:ListItem Text="Walking" Value="walking"></asp:ListItem>
                <asp:ListItem Text="Casual" Value="casual"></asp:ListItem>
                <asp:ListItem Text="Formal" Value="formal"></asp:ListItem>
                <asp:ListItem Text="Others" Value="others"></asp:ListItem>       
            </asp:DropDownList>
    </div>

    <div class="mb-3">
        <label for="disabledTextInput" class="form-label">Price</label>
        <asp:TextBox ID="txt_Price" class="form-control" runat="server"></asp:TextBox>
    </div>
          <asp:Button ID="btn_AddProduct" class="btn btn-primary" runat="server" Text="Submit" OnClick="btn_AddProduct_Click" />

   <h3>Add Product Size and Quantity</h3>
          <h5><span><asp:Label ID="lblsqadded" Style="color:midnightblue" runat="server" Text=""></asp:Label></span></h5>
          <br />
          <br />
    <div class="mb-3">
        <label for="disabledTextInput" class="form-label">Product ID</label>
        <asp:TextBox ID="txt_ProductID"  class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="mb-3">
            <label for="disabledSelect" class="form-label">Size</label>
            <asp:DropDownList ID="list_size" runat="server" CssClass="form-control">
                <asp:ListItem Text="-- Select --" Value=""></asp:ListItem>
                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                <asp:ListItem Text="10" Value="10"></asp:ListItem>                   
            </asp:DropDownList>
    </div>



    <div class="mb-3">
        <label for="disabledTextInput" class="form-label">Quantity</label>
        <asp:TextBox ID="txt_quantity" class="form-control" runat="server"></asp:TextBox>
    </div>

          <div class="row">
              <div class="col">
                  <asp:Button ID="btn_sqadded" class="btn btn-primary" runat="server" Text="ADD" OnClick="btn_sqadded_Click" />
              </div>
               <div class="col">
                   <asp:Button ID="btn_done" class="btn btn-success" runat="server" Text="DONE" OnClick="btn_done_Click" />              
               </div>
          </div>
          <br />
          <br />
      </div>

        

      <div class="col-lg-7" style="background-color: #e0e0e0;">
          <div class="row">
              <div class="col">
            <div class="container">

            <h2>Products</h2>
            <!-- GridView with Bootstrap table classes -->
            <asp:GridView ID="grid_PSQ" runat="server" AutoGenerateColumns="true" CssClass="table table-striped table-bordered"></asp:GridView>
                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Size" HeaderText="Size" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                </Columns>
        </div>    
       </div>
    <div class="col">       
<div class="container">
    <h2>Final Total quantity</h2>
   
   
     <asp:GridView ID="grid_final" runat="server" AutoGenerateColumns="true" CssClass="table table-striped table-bordered"> </asp:GridView>
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
            <asp:BoundField DataField="TotalQuantity" HeaderText="Total Quantity" />
        </Columns>
       
</div>
    </div>
    </div>     
      </div>
    </div>
      </form>
  </div>
  

    <!-- Start Script -->
    <script src="assets/js/jquery-1.11.0.min.js"></script>
    <script src="assets/js/jquery-migrate-1.2.1.min.js"></script>
    <script src="assets/js/bootstrap.bundle.min.js"></script>
    <script src="assets/js/templatemo.js"></script>
    <script src="assets/js/custom.js"></script>
    <!-- End Script -->
</body>

</html>
