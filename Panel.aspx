<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Panel.aspx.cs" Inherits="webAI_UNAM.Panel" %>



<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="Responsive sidebar template with sliding effect and dropdown menu based on bootstrap 3">
    <title>Sidebar template</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/fontawesome-all.min.css" rel="stylesheet" />
    <link href="Estilos/Panel.css" rel="stylesheet" />
    <link href="Estilos/Estilos.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>

<body>
    <script>
        jQuery(function ($) {

            $(".sidebar-dropdown > a").click(function () {
                $(".sidebar-submenu").slideUp(200);
                if (
                    $(this)
                        .parent()
                        .hasClass("active")
                ) {
                    $(".sidebar-dropdown").removeClass("active");
                    $(this)
                        .parent()
                        .removeClass("active");
                } else {
                    $(".sidebar-dropdown").removeClass("active");
                    $(this)
                        .next(".sidebar-submenu")
                        .slideDown(200);
                    $(this)
                        .parent()
                        .addClass("active");
                }
            });

            $("#close-sidebar").click(function () {
                $(".page-wrapper").removeClass("toggled");
            });
            $("#show-sidebar").click(function () {
                $(".page-wrapper").addClass("toggled");
            });

        });
    </script>

    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="page-wrapper chiller-theme toggled">
            <a id="show-sidebar" class="btn btn-sm btn-dark" href="#">
                <i class="fas fa-bars"></i>
            </a>
            <nav id="sidebar" class="sidebar-wrapper">
                <div class="sidebar-content">
                    <div class="sidebar-brand">
                        <a href="#">pro sidebar</a>
                        <div id="close-sidebar">
                            <i class="fas fa-times"></i>
                        </div>
                    </div>
                    <div class="sidebar-header">
                        <div class="user-pic">
                            <img class="img-responsive img-rounded" src="https://raw.githubusercontent.com/azouaoui-med/pro-sidebar-template/gh-pages/src/img/user.jpg"
                                alt="User picture">
                        </div>
                        <div class="user-info">
                            <span class="user-name">Jhon
           
                            <strong>Smith</strong>
                            </span>
                            <span class="user-role">Administrator</span>
                            <span class="user-status">
                                <i class="fa fa-circle"></i>
                                <span>Online</span>
                            </span>
                        </div>
                    </div>
                    <!-- sidebar-header  -->
                    <div class="sidebar-search">
                        <div>
                            <div class="input-group">
                                <input type="text" class="form-control search-menu" placeholder="Search...">
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="fa fa-search" aria-hidden="true"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- sidebar-search  -->
                    <div class="sidebar-menu">
                        <ul>
                            <li class="header-menu">
                                <span>Materias</span>
                            </li>
                            <asp:UpdatePanel ID="upMateria0001" runat="server" UpdateMode="Conditional" >
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lkbMateria0001" EventName="Click" />
                                </Triggers>
                                <ContentTemplate>
                                    <li class="sidebar-dropdown">

                                        <asp:LinkButton ID="lkbMateria0001" runat="server" href="#">

                                            <i class="fas fa-microscope" runat="server" id="iM001"></i>

                                            <span>
                                                <asp:Label ID="lblMateria001" runat="server"></asp:Label></span>
                                        </asp:LinkButton>

                                        <div class="sidebar-submenu">
                                            <ul>
                                                <asp:UpdatePanel ID="upMateria0001Tema0001" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0001" runat="server" OnClick="lkbMateria0001Tema0001_Click">
                                                                <span>Tema 1 <i class="fa fa-circle" runat="server" id="iM001Tema001" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0002" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0002" runat="server">
                                                                <span>Tema 2 <i class="fa fa-circle" runat="server" id="i1" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0003" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0003" runat="server">
                                                                <span>Tema 3 <i class="fa fa-circle" runat="server" id="i2" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0004" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0004" runat="server">
                                                                <span>Tema 4 <i class="fa fa-circle" runat="server" id="i3" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0005" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0005" runat="server">
                                                                <span>Tema 5 <i class="fa fa-circle" runat="server" id="i4" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0006" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0006" runat="server">
                                                                <span>Tema 6 <i class="fa fa-circle" runat="server" id="i5" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0007" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0007" runat="server">
                                                                <span>Tema 7 <i class="fa fa-circle" runat="server" id="i6" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0008" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0008" runat="server">
                                                                <span>Tema 8 <i class="fa fa-circle" runat="server" id="i7" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema00089" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0009" runat="server">
                                                                <span>Tema 9 <i class="fa fa-circle" runat="server" id="i8" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0010" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0010" runat="server">
                                                                <span>Tema 10 <i class="fa fa-circle" runat="server" id="i9" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0011" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0011" runat="server">
                                                                <span>Tema 11 <i class="fa fa-circle" runat="server" id="i10" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0012" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0012" runat="server">
                                                                <span>Tema 12 <i class="fa fa-circle" runat="server" id="i11" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </ul>
                                        </div>
                                    </li>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="upMateria0002" runat="server" UpdateMode="Conditional" >
                                <ContentTemplate>
                                    <li class="sidebar-dropdown">

                                        <asp:LinkButton ID="lkbMateria0002" runat="server" href="#">
                                            <i class="fas fa-spell-check"></i>
                                            <span>
                                                <asp:Label ID="lblMateria002" runat="server"></asp:Label></span>
                                        </asp:LinkButton>

                                        <div class="sidebar-submenu">
                                            <ul>
                                                <asp:UpdatePanel ID="upMateria0002Tema0001" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0001" runat="server" OnClick="lkbMateria0002Tema0001_Click">
                                                                <span>Tema 1 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0001" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema0002" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0002" runat="server" OnClick="lkbMateria0002Tema0002_Click">
                                                                <span>Tema 2 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0002" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema0003" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0003" runat="server" OnClick="lkbMateria0002Tema0003_Click">
                                                                <span>Tema 3 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0003" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema0004" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0004" runat="server" OnClick="lkbMateria0002Tema0004_Click">
                                                                <span>Tema 4 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0004" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema0005" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0005" runat="server" OnClick="lkbMateria0002Tema0005_Click">
                                                                <span>Tema 5 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0005" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema0006" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0006" runat="server" OnClick="lkbMateria0002Tema0006_Click">
                                                                <span>Tema 6 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0006" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema0007" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0007" runat="server" OnClick="lkbMateria0002Tema0007_Click">
                                                                <span>Tema 7 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0007" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema0008" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0008" runat="server" OnClick="lkbMateria0002Tema0008_Click">
                                                                <span>Tema 8 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0008" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema00089" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0009" runat="server" OnClick="lkbMateria0002Tema0009_Click">
                                                                <span>Tema 9 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0009" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema0010" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0010" runat="server" OnClick="lkbMateria0002Tema0010_Click">
                                                                <span>Tema 10 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0010" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ul>
                                        </div>
                                    </li>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="upDatos" runat="server" UpdateMode="Conditional" >
                                <ContentTemplate>
                                    <li class="sidebar-dropdown">

                                        <asp:LinkButton ID="lkbDatos" runat="server" href="#">
                                <i class="fas fa-tools"></i>
                                <span>Datos</span>
                                        </asp:LinkButton>

                                        <div class="sidebar-submenu">
                                            <ul>
                                                <asp:UpdatePanel ID="upNotificacion" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbNotificacion" runat="server">
                                  <span>Notificación</span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upCentro" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbCentro" runat="server">
                                  <span>Centro</span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upUsuarios" runat="server" UpdateMode="Conditional" >
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbUsuarios" runat="server">
                                  <span>Usuarios</span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </ul>
                                        </div>
                                    </li>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </ul>
                    </div>
                    <!-- sidebar-menu  -->
                </div>
                <!-- sidebar-content  -->
                <div class="sidebar-footer">
                    <a href="#">
                        <i class="fa fa-bell"></i>
                        <span class="badge badge-pill badge-warning notification">3</span>
                    </a>
                    <a href="#">
                        <i class="fa fa-envelope"></i>
                        <span class="badge badge-pill badge-success notification">7</span>
                    </a>
                    <a href="#">
                        <i class="fa fa-cog"></i>
                        <span class="badge-sonar"></span>
                    </a>
                    <a href="#">
                        <i class="fa fa-power-off"></i>
                    </a>
                </div>
            </nav>
            <!-- sidebar-wrapper  -->
            <main class="page-content">
                <asp:UpdatePanel ID="upContainer" runat="server" UpdateMode="Conditional" >
                    <ContentTemplate>
                        <div class="container-fluid" runat="server" id="divContainer">

                            <div class="card text-right">
                                <div class="card-header text-right">
                                    <h2>Resumen</h2>
                                </div>
                                <div class="card-body">


                                    <h6>Aprovechamiento</h6>
                                    <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                    <div class="progress">
                                        <div class="progress-bar bg-c-red" style="width: 0%"></div>
                                    </div>

                                    <br />

                                    <h6>Oportunidad</h6>
                                    <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                    <div class="progress">
                                        <div class="progress-bar bg-c-green" style="width: 0%"></div>
                                    </div>

                                </div>

                            </div>
                            <hr />
                            <div class="card-deck">
                                <div class="card" style="width: 18rem;">
                                    <img class="card-img-top" src="Imagenes/PicUNAM/card01.png" alt="Card image cap">
                                    <div class="card-body">
                                        <h6>Diagnostico</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-red" style="width: 0%"></div>
                                        </div>
                                        <br />
                                        <h6>Evaluación</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-green" style="width: 0%"></div>
                                        </div>
                                    </div>

                                </div>
                                <div class="card" style="width: 18rem;">
                                    <img class="card-img-top" src="Imagenes/PicUNAM/card02.png" alt="Card image cap">
                                    <div class="card-body">
                                        <h6>Diagnostico</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-red" style="width: 0%"></div>
                                        </div>
                                        <br />
                                        <h6>Evaluación</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-green" style="width: 0%"></div>
                                        </div>
                                    </div>

                                </div>
                                <div class="card" style="width: 18rem;">
                                    <img class="card-img-top" src="Imagenes/PicUNAM/card01.png" alt="Card image cap">
                                    <div class="card-body">
                                        <h6>Diagnostico</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-red" style="width: 0%"></div>
                                        </div>
                                        <br />
                                        <h6>Evaluación</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-green" style="width: 0%"></div>
                                        </div>
                                    </div>

                                </div>
                                <div class="card" style="width: 18rem;">
                                    <img class="card-img-top" src="Imagenes/PicUNAM/card01.png" alt="Card image cap">
                                    <div class="card-body">
                                        <h6>Diagnostico</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-red" style="width: 0%"></div>
                                        </div>
                                        <br />
                                        <h6>Evaluación</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-green" style="width: 0%"></div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <br />
                            <div class="card-deck">
                                <div class="card" style="width: 18rem;">
                                    <img class="card-img-top" src="Imagenes/PicUNAM/card01.png" alt="Card image cap">
                                    <div class="card-body">
                                        <h6>Diagnostico</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-red" style="width: 0%"></div>
                                        </div>
                                        <br />
                                        <h6>Evaluación</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-green" style="width: 0%"></div>
                                        </div>
                                    </div>

                                </div>
                                <div class="card" style="width: 18rem;">
                                    <img class="card-img-top" src="Imagenes/PicUNAM/card01.png" alt="Card image cap">
                                    <div class="card-body">
                                        <h6>Diagnostico</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-red" style="width: 0%"></div>
                                        </div>
                                        <br />
                                        <h6>Evaluación</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-green" style="width: 0%"></div>
                                        </div>
                                    </div>
                                </div>
                                <div class="card" style="width: 18rem;">
                                    <img class="card-img-top" src="Imagenes/PicUNAM/card01.png" alt="Card image cap">
                                    <div class="card-body">
                                        <h6>Diagnostico</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-red" style="width: 0%"></div>
                                        </div>
                                        <br />
                                        <h6>Evaluación</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-green" style="width: 0%"></div>
                                        </div>
                                    </div>
                                </div>
                                <div class="card" style="width: 18rem;">
                                    <img class="card-img-top" src="Imagenes/PicUNAM/card01.png" alt="Card image cap">
                                    <div class="card-body">
                                        <h6>Diagnostico</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-red" style="width: 0%"></div>
                                        </div>
                                        <br />
                                        <h6>Evaluación</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-green" style="width: 0%"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="card-deck">
                                <div class="card" style="width: 18rem;">
                                    <img class="card-img-top" src="Imagenes/PicUNAM/card01.png" alt="Card image cap">
                                    <div class="card-body">
                                        <h6>Diagnostico</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-red" style="width: 0%"></div>
                                        </div>
                                        <br />
                                        <h6>Evaluación</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-green" style="width: 0%"></div>
                                        </div>
                                    </div>
                                </div>
                                <div class="card" style="width: 18rem;">
                                    <img class="card-img-top" src="Imagenes/PicUNAM/card01.png" alt="Card image cap">
                                    <div class="card-body">
                                        <h6>Diagnostico</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-red" style="width: 0%"></div>
                                        </div>
                                        <br />
                                        <h6>Evaluación</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-green" style="width: 0%"></div>
                                        </div>
                                    </div>
                                </div>
                                <div class="card" style="width: 18rem;">
                                    <img class="card-img-top" src="Imagenes/PicUNAM/card01.png" alt="Card image cap">
                                    <div class="card-body">
                                        <h6>Diagnostico</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-red" style="width: 0%"></div>
                                        </div>
                                        <br />
                                        <h6>Evaluación</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-green" style="width: 0%"></div>
                                        </div>
                                    </div>
                                </div>
                                <div class="card" style="width: 18rem;">
                                    <img class="card-img-top" src="Imagenes/PicUNAM/card01.png" alt="Card image cap">
                                    <div class="card-body">
                                        <h6>Diagnostico</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-red" style="width: 0%"></div>
                                        </div>
                                        <br />
                                        <h6>Evaluación</h6>
                                        <h5 class="m-b-30 f-w-700">0<span class="text-c-green m-l-10">0 %</span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-green" style="width: 0%"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="upTema" runat="server" UpdateMode="Conditional" >
                    <ContentTemplate>
                        <div class="container-fluid" id="divTema" runat="server" visible="false">
                            <div class="card ">
                                <div class="card-header ">
                                    <h5>
                                        <asp:Label ID="lblTema" CssClass="modal-title" runat="server" Text=""></asp:Label></h5>
                                </div>
                                <div class="card-body">

                                    <div class="row no-gutters">
                                        <div class="col-md-4">
                                            <video id="play_video" runat="server" visible="false" class="img-thumbnail" controls="controls" controlslist="nodownload">
                                                <source src="" type='video/mp4;codecs="avc1.42E01E, mp4a.40.2"' />
                                            </video>
                                        </div>
                                        <div class="col-md-8">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-10">

                                                        <p class="card-text">Instrucciones</p>
                                                        <p class="card-text"><small class="text-muted">* <strong>Primero: </strong>Debes escuchar con atención tu vídeo clase, la puedes pausar y ver las veces que sean necesarias</p>
                                                        </small>
                                                            <p class="card-text"><small class="text-muted"><a>* <strong>Segundo: </strong>Toma apuntes, serán importantes para realizar tus evaluaciones o cuestionarios</a></small></p>
                                                        <br />
                                                        <asp:UpdatePanel ID="upComenzar" runat="server" UpdateMode="Conditional" >
                                                            <ContentTemplate>
                                                                <asp:Button CssClass="btn btn-secondary" aling="right" ID="btnDiagnostico" runat="server" Text="Comenzar" TabIndex="2" OnClick="btnDiagnostico_Click" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <p class="card-text text-center"><small class="text-muted"><strong>Puntuación</strong></p>
                                                        <h1 class="text-center">
                                                            <asp:Label ID="lblPuntDiag" runat="server" Text="0"></asp:Label></h1>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="upDiagnostico" runat="server" UpdateMode="Conditional" >
                    <ContentTemplate>
                        <div class="container-fluid" id="divDiagnostico" runat="server" visible="false">
                            <div class="card">
                                <div class="card-body">
                                    <h5 runat="server" id="H2" title="uno">
                                        <asp:Label ID="lblTemaDiagnostico" CssClass="modal-title" runat="server" Text=""></asp:Label>
                                    </h5>

                                    <div class="row">
                                        <br />
                                        <div class="col-md-6" runat="server">
                                            <asp:UpdatePanel ID="upRespDiag001" runat="server" UpdateMode="Conditional" >
                                                <ContentTemplate>
                                                    <asp:RadioButton runat="server" ID="rbRespDiag001" GroupName="radioA" AutoPostBack="True" />
                                                    <label for="rbRespDiag001">
                                                        <asp:Label ID="lblRespDiag001" runat="server" Text="">
                                                        </asp:Label><asp:Label ID="lblRespDiagID001" runat="server" Text="" Visible="false"></asp:Label></label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <br />
                                            <asp:UpdatePanel ID="upRespDiag002" runat="server" UpdateMode="Conditional" >
                                                <ContentTemplate>
                                                    <asp:RadioButton runat="server" ID="rbRespDiag002" GroupName="radioA" AutoPostBack="True" />
                                                    <label for="rbRespDiag002">
                                                        <asp:Label ID="lblRespDiag002" runat="server" Text=""></asp:Label>
                                                        <asp:Label ID="lblRespDiagID002" runat="server" Text="" Visible="false"></asp:Label></label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <br />
                                        </div>
                                        <div class="col-md-6" runat="server">
                                            <asp:UpdatePanel ID="upRespDiag003" runat="server" UpdateMode="Conditional" >
                                                <ContentTemplate>
                                                    <asp:RadioButton runat="server" ID="rbRespDiag003" GroupName="radioA" AutoPostBack="True" />
                                                    <label for="rbRespDiag003">
                                                        <asp:Label ID="lblRespDiag003" runat="server" Text="">
                                                        </asp:Label><asp:Label ID="lblRespDiagID003" runat="server" Text="" Visible="false"></asp:Label></label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <br />
                                            <asp:UpdatePanel ID="upRespDiag004" runat="server" UpdateMode="Conditional" >
                                                <ContentTemplate>
                                                    <asp:RadioButton runat="server" ID="rbRespDiag004" GroupName="radioA" AutoPostBack="True" />
                                                    <label for="rbRespDiag004">
                                                        <asp:Label ID="lblRespDiag004" runat="server" Text="">
                                                        </asp:Label><asp:Label ID="lblRespDiagID004" runat="server" Text="" Visible="false"></asp:Label></label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <br />
                                        </div>
                                    </div>

                                    <asp:UpdatePanel ID="upGuardaDiagnostico" runat="server" UpdateMode="Conditional" >
                                        <ContentTemplate>
                                            <asp:Button CssClass="btn btn-secondary" aling="right" ID="btnGuardaDiagnostico" runat="server" Text="Guardar" TabIndex="18" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress ID="upCarga" runat="server" DynamicLayout="true">
                                        <ProgressTemplate>
                                            <div id="overlay">
                                                <div class="center">
                                                    <img alt="" src="Imagenes/ajax-loader.gif" />
                                                </div>
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="upComentario" runat="server" UpdateMode="Conditional"  >
                    <ContentTemplate>
                        <div class="container-fluid" id="divComentario" runat="server" visible="false">
                            <div class="card ">
                                <div class="card-header ">
                                    <h4>
                                        <label for="comment">Síntesis:</label></h4>
                                </div>
                                <div class="card-body">
                                    <textarea class="form-control" rows="4" id="comment1" runat="server" required="required" tabindex="1"></textarea>
                                    <br />
                                    <asp:Button CssClass="btn btn-secondary" aling="right" ID="btnIniciar" runat="server" Text="Enviar" TabIndex="2" />
                                </div>
                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </main>

            <!-- page-content" -->
        </div>
        <div class="modal" id="myModal">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional" >
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:Label ID="lblModalTitle" CssClass="modal-title" runat="server" Text=""></asp:Label>
                                <button type="button" class="close" data-dismiss="modal"><span>×</span> </button>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblModalBody" CssClass="login100-form-title" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="modal-footer">

                                <button type="button" class="btn btn-danger" data-dismiss="modal">Aceptar</button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>

</body>

</html>
