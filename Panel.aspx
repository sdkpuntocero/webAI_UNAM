<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Panel.aspx.cs" Inherits="webAI_UNAM.Panel" %>



<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="Porque Intelimundo es el complemento perfecto para mejorar la vida académica del alumno, desarrollando y favoreciendo habilidades, aptitudes y actitudes ...">
    <title>\ Aula - UNAM</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/fontawesome-all.min.css" rel="stylesheet" />
    <link href="Estilos/Panel.css" rel="stylesheet" />
    <link href="Estilos/Estilos.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="js/jquery.timers.js"></script>
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
        $(function () {
            $(document).bind("contextmenu", function (e) {
                return false;
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
                        <a href="#">Intelimundo</a>
                        <div id="close-sidebar">
                            <i class="fas fa-times"></i>
                        </div>
                    </div>
                    <div class="sidebar-header">
                        <div class="user-pic">
                            <img class="img-responsive img-rounded" src="https://raw.githubusercontent.com/azouaoui-med/pro-sidebar-template/gh-pages/src/img/user.jpg"
                                alt="User picture"/>
                        </div>
                        <div class="user-info">
                            <span class="user-name">
                                <asp:Label ID="lblNombreUsuario" runat="server" Text=""></asp:Label>
                                <strong>

                                    <asp:Label ID="lblNombreApellidos" runat="server" Text=""></asp:Label>
                                </strong>
                            </span>
                            <span class="user-role">
                                <asp:Label ID="lblCorporativo" runat="server" Text="" Font-Size="Smaller"></asp:Label></span>
                            <span class="user-role">
                                <asp:Label ID="lblOperadora" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                            </span>
                            <span class="user-status">

                                <i class="fa fa-circle" runat="server" id="i_EstatusUsuario" style="color: #bf474e"></i>
                                <span>
                                    <asp:Label ID="lbl_EstatusUsuario" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                                </span>
                            </span>
                        </div>
                    </div>
                    <!-- sidebar-header  -->
                    <div class="sidebar-search">
                        <div>
                            <div class="input-group">
                                <input type="text" class="form-control search-menu" placeholder="Buscar...">
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
                            <asp:UpdatePanel ID="upResumen" runat="server" UpdateMode="Conditional">

                                <ContentTemplate>
                                    <li>

                                        <asp:LinkButton ID="lkbResumen" runat="server" OnClick="lkbResumen_Click">
                                            <i class="fas fa-tachometer-alt" runat="server" id="iResumen"></i>
                                            <span>
                                                <asp:Label ID="lblResumen" runat="server" Text="Resumen"></asp:Label></span>
                                        </asp:LinkButton>
                                    </li>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel ID="upMateria0001" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lkbMateria0001" EventName="Click" />
                                </Triggers>
                                <ContentTemplate>
                                    <li class="sidebar-dropdown">

                                        <asp:LinkButton ID="lkbMateria0001" runat="server" href="#" OnClick="lkbMateria0001_Click" Visible="false">

                                            <i class="fas fa-microscope" runat="server" id="iM001"></i>

                                            <span>
                                                <asp:Label ID="lblMateria001" runat="server"></asp:Label></span>
                                        </asp:LinkButton>

                                        <div class="sidebar-submenu">
                                            <ul>
                                                <asp:UpdatePanel ID="upMateria0001Tema0001" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0001" runat="server" OnClick="lkbMateria0001Tema0001_Click">
                                                                <span>Tema 1 <i class="fa fa-circle" runat="server" id="iM001Tema001" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0002" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0002" runat="server">
                                                                <span>Tema 2 <i class="fa fa-circle" runat="server" id="iM001Tema002" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0003" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0003" runat="server">
                                                                <span>Tema 3 <i class="fa fa-circle" runat="server" id="iM001Tema003" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0004" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0004" runat="server">
                                                                <span>Tema 4 <i class="fa fa-circle" runat="server" id="iM001Tema004" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0005" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0005" runat="server">
                                                                <span>Tema 5 <i class="fa fa-circle" runat="server" id="iM001Tema005" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0006" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0006" runat="server">
                                                                <span>Tema 6 <i class="fa fa-circle" runat="server" id="iM001Tema006" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0007" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0007" runat="server">
                                                                <span>Tema 7 <i class="fa fa-circle" runat="server" id="iM001Tema007" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0008" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0008" runat="server">
                                                                <span>Tema 8 <i class="fa fa-circle" runat="server" id="iM001Tema008" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0009" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0009" runat="server">
                                                                <span>Tema 9 <i class="fa fa-circle" runat="server" id="iM001Tema009" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0010" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0010" runat="server">
                                                                <span>Tema 10 <i class="fa fa-circle" runat="server" id="iM001Tema010" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0011" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0011" runat="server">
                                                                <span>Tema 11 <i class="fa fa-circle" runat="server" id="iM001Tema0011" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0001Tema0012" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0001Tema0012" runat="server">
                                                                <span>Tema 12 <i class="fa fa-circle" runat="server" id="iM001Tema012" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </ul>
                                        </div>
                                    </li>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="upMateria0002" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <li class="sidebar-dropdown">

                                        <asp:LinkButton ID="lkbMateria0002" runat="server" href="#">
                                            <i class="fas fa-spell-check" runat="server" id="iM002"></i>
                                            <span>
                                                <asp:Label ID="lblMateria002" runat="server"></asp:Label></span>
                                        </asp:LinkButton>

                                        <div class="sidebar-submenu">
                                            <ul>
                                                <asp:UpdatePanel ID="upMateria0002Tema0001" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0001" runat="server" OnClick="lkbMateria0002Tema0001_Click">
                                                                <span>Tema 1 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0001" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema0002" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0002" runat="server" OnClick="lkbMateria0002Tema0002_Click">
                                                                <span>Tema 2 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0002" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema0003" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0003" runat="server" OnClick="lkbMateria0002Tema0003_Click">
                                                                <span>Tema 3 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0003" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema0004" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0004" runat="server" OnClick="lkbMateria0002Tema0004_Click">
                                                                <span>Tema 4 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0004" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema0005" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0005" runat="server" OnClick="lkbMateria0002Tema0005_Click">
                                                                <span>Tema 5 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0005" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema0006" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0006" runat="server" OnClick="lkbMateria0002Tema0006_Click">
                                                                <span>Tema 6 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0006" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema0007" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0007" runat="server" OnClick="lkbMateria0002Tema0007_Click">
                                                                <span>Tema 7 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0007" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema0008" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0008" runat="server" OnClick="lkbMateria0002Tema0008_Click">
                                                                <span>Tema 8 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0008" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema0009" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbMateria0002Tema0009" runat="server" OnClick="lkbMateria0002Tema0009_Click">
                                                                <span>Tema 9 <i class="fa fa-circle" runat="server" id="iMateria0002Tema0009" style="color: #dc3545"></i></span>
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel ID="upMateria0002Tema0010" runat="server" UpdateMode="Conditional">
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
                            <asp:UpdatePanel ID="upDatos" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <li class="sidebar-dropdown">

                                        <asp:LinkButton ID="lkbDatos" runat="server" href="#" Visible="false">
                                <i class="fas fa-tools"></i>
                                <span>Datos</span>
                                        </asp:LinkButton>

                                        <div class="sidebar-submenu">
                                            <ul>
                                                <asp:UpdatePanel ID="upUsuarios" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <li>
                                                            <asp:LinkButton ID="lkbUsuarios" runat="server" OnClick="lkbUsuarios_Click">
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
              <%--      <a href="#">
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
                    </a>--%>
                   <asp:LinkButton ID="lkbSalir" runat="server" OnClick="lkbSalir_Click">
                        <i class="fa fa-power-off"></i>
                                </asp:LinkButton>
                </div>
            </nav>
            <!-- sidebar-wrapper  -->
            <main class="page-content">
                 <div class="col-xs-12 col-md-12">
                <asp:UpdatePanel ID="upContainer" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="container-fluid" runat="server" id="divContainer">

                            <div class="card text-right">
                                <div class="card-header text-right">
                                    <h2>Resumen</h2>
                                </div>
                                <div class="card-body">


                                    <h6>Aprovechamiento</h6>
                                    <h5 class="m-b-30 f-w-700">
                                        <asp:Label ID="lblACr" runat="server" Font-Size="Smaller"></asp:Label><span class="text-c-green m-l-10"><asp:Label ID="lblAC" runat="server" Font-Size="Smaller"></asp:Label></span></h5>
                                    <div class="progress">
                                        <div class="progress-bar bg-c-red" style="width: 0%" runat="server" id="divAC"></div>
                                    </div>

                                    <br />

                                    <h6>Oportunidad</h6>
                                    <h5 class="m-b-30 f-w-700">
                                        <asp:Label ID="lblOCr" runat="server" Font-Size="Smaller"></asp:Label><span class="text-c-green m-l-10"><asp:Label ID="lblOC" runat="server" Font-Size="Smaller"></asp:Label></span></h5>
                                    <div class="progress">
                                        <div class="progress-bar bg-c-green" style="width: 0%" runat="server" id="divOC"></div>
                                    </div>

                                </div>

                            </div>
                            <hr />
                            <div class="card-deck">
                                <div class="card" style="width: 18rem;">
                                    <img class="card-img-top" src="Imagenes/PicUNAM/card01.png" alt="Card image cap">
                                    <div class="card-body">
                                        <h6>Diagnostico</h6>
                                        <h5 class="m-b-30 f-w-700">
                                            <asp:Label ID="lblMatR001D" runat="server" Font-Size="Smaller"></asp:Label><span class="text-c-green m-l-10"><asp:Label ID="lblMat001D" runat="server" Font-Size="Smaller"></asp:Label></span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-red" style="width: 0%" runat="server" id="divMat001D">
                                            </div>
                                        </div>
                                        <br />
                                        <h6>Evaluación</h6>
                                        <h5 class="m-b-30 f-w-700">
                                            <asp:Label ID="lblMatR001C" runat="server" Font-Size="Smaller"></asp:Label><span class="text-c-green m-l-10"><asp:Label ID="lblMat001C" runat="server" Font-Size="Smaller"></asp:Label></span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-green" style="width: 0%" runat="server" id="divMat001C"></div>
                                        </div>
                                    </div>

                                </div>
                                <div class="card" style="width: 18rem;">
                                    <img class="card-img-top" src="Imagenes/PicUNAM/card02.png" alt="Card image cap">
                                    <div class="card-body">
                                        <h6>Diagnostico</h6>
                                        <h5 class="m-b-30 f-w-700">
                                            <asp:Label ID="lblMatR002D" runat="server" Font-Size="Smaller"></asp:Label></span><span class="text-c-green m-l-10"><asp:Label ID="lblMat002D" runat="server" Font-Size="Smaller"></asp:Label></span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-red" style="width: 0%" runat="server" id="divMat002D"></div>
                                        </div>
                                        <br />
                                        <h6>Evaluación</h6>
                                        <h5 class="m-b-30 f-w-700">
                                            <asp:Label ID="lblMatR002C" runat="server" Font-Size="Smaller"></asp:Label><span class="text-c-green m-l-10"><asp:Label ID="lblMat002C" runat="server" Font-Size="Smaller"></asp:Label></span></h5>
                                        <div class="progress">
                                            <div class="progress-bar bg-c-green" style="width: 0%" runat="server" id="divMat002C"></div>
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
                <asp:UpdatePanel ID="upTema" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="container-fluid" id="divTema" runat="server" visible="false">
                            <div class="card ">
                                <div class="card-header ">
                                    <h5>
                                        <asp:Label ID="lblTema" CssClass="modal-title" runat="server" Text=""></asp:Label></h5>
                                </div>
                                <div class="card-body">

                                    <div class="row no-gutters">
                                        <div class="col-md-4 text-center">
                                            <video width="250" height="150" id="play_video" runat="server" visible="false" class="img-thumbnail" controls="controls" controlslist="nodownload">
                                                <source src="" type='video/mp4;codecs="avc1.42E01E, mp4a.40.2"' />
                                            </video>
                                        </div>
                                        <div class="col-md-8">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-10">

                                                        <p class="card-text">Instrucciones Diagnostico</p>
                                                        <p class="card-text"><small class="text-muted">* <strong>Primero: </strong>Debes escuchar con atención tu vídeo clase, la puedes pausar y ver las veces que sean necesarias</p>
                                                        </small>
                                                            <p class="card-text"><small class="text-muted"><a>* <strong>Segundo: </strong>Toma apuntes, serán importantes para realizar tus evaluaciones o cuestionarios</a></small></p>
                                                        <br />
                                                        <asp:UpdatePanel ID="upComenzar" runat="server" UpdateMode="Conditional">
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
                                    <br />
                                    <div class="row no-gutters" runat="server" id="divEbook" visible="false">
                                        <div class="col-md-4">

                                            <iframe width="250" height="150" runat="server" id="iframeTema" class="card-img" src=""></iframe>
                                        </div>
                                        <div class="col-md-8">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-10">

                                                        <p class="card-text">Instrucciones Cuestionario</p>
                                                        <p class="card-text">* <strong>Primero: </strong>Debes de leer con atención tu Ebook y tomar apuntes que serán necesarios para la realización de tu síntesis</p>

                                                        <p class="card-text">
                                                            <a>* <strong>Segundo: </strong>Tu síntesis debe ser de un mínimo de 1800 caracteres equivalente a un poco mas de media cuartilla</a>
                                                            <br />
                                                            <a><strong>¡ Recuerda ! </strong>Sólo puedes realizar una vez el cuestionario de cada tema, así que toma apuntes... te servirán de repaso.</a>
                                                        </p>
                                                        <br />
                                                    </div>
                                                    <div class="col-md-2">
                                                        <p class="card-text text-center"><strong>Puntuación</strong></p>
                                                        <h1 class="text-center">
                                                            <asp:Label ID="lblPuntuacion" runat="server" Text="0"></asp:Label></h1>
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
                <asp:UpdatePanel ID="upDiagnostico" runat="server" UpdateMode="Conditional">
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
                                            <asp:UpdatePanel ID="upRespDiag001" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton runat="server" ID="rbRespDiag001" GroupName="radioA" AutoPostBack="True" />
                                                    <label for="rbRespDiag001">
                                                        <asp:Label ID="lblRespDiag001" runat="server" Text="">
                                                        </asp:Label><asp:Label ID="lblRespDiagID001" runat="server" Text="" Visible="false"></asp:Label></label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <br />
                                            <asp:UpdatePanel ID="upRespDiag002" runat="server" UpdateMode="Conditional">
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
                                            <asp:UpdatePanel ID="upRespDiag003" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton runat="server" ID="rbRespDiag003" GroupName="radioA" AutoPostBack="True" />
                                                    <label for="rbRespDiag003">
                                                        <asp:Label ID="lblRespDiag003" runat="server" Text="">
                                                        </asp:Label><asp:Label ID="lblRespDiagID003" runat="server" Text="" Visible="false"></asp:Label></label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <br />
                                            <asp:UpdatePanel ID="upRespDiag004" runat="server" UpdateMode="Conditional">
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

                                    <asp:UpdatePanel ID="upGuardaDiagnostico" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Button CssClass="btn btn-secondary" aling="right" ID="btnGuardaDiagnostico" runat="server" Text="Guardar" TabIndex="18" OnClick="btnGuardaDiagnostico_Click" />
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
                <asp:UpdatePanel ID="upComentario" runat="server" UpdateMode="Conditional">
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
                                    <asp:Button CssClass="btn btn-secondary" aling="right" ID="btnEnviar" runat="server" Text="Enviar" TabIndex="2" OnClick="btnEnviar_Click" />
                                </div>
                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="upPreguntas" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="container-fluid" id="divPreguntas" runat="server" visible="false">
                            <div class="card">
                                <div class="card-body">
                                    <h5 runat="server" id="PreguntaID" title="uno">
                                        <asp:Label ID="lblPregunta" CssClass="modal-title" runat="server" Text=""></asp:Label>
                                    </h5>
                                    <div class="row">

                                        <div class="col-md-6" runat="server">
                                            <asp:UpdatePanel ID="upR1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton runat="server" ID="radioR1" GroupName="radioA" AutoPostBack="True" />
                                                    <label for="radioR1">
                                                        <asp:Label ID="lblRespuesta001" runat="server" Text=""></asp:Label><asp:Label ID="lblResp001" runat="server" Text="" Visible="false"></asp:Label></label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <br />
                                            <asp:UpdatePanel ID="upR2" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton runat="server" ID="radioR2" GroupName="radioA" AutoPostBack="True" />
                                                    <label for="radioR2">
                                                        <asp:Label ID="lblRespuesta002" runat="server" Text=""></asp:Label><asp:Label ID="lblResp002" runat="server" Text="" Visible="false"></asp:Label></label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <br />
                                        </div>
                                        <div class="col-md-6" runat="server">
                                            <asp:UpdatePanel ID="upR3" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton runat="server" ID="radioR3" GroupName="radioA" AutoPostBack="True" />
                                                    <label for="radioR3">
                                                        <asp:Label ID="lblRespuesta003" runat="server" Text=""></asp:Label><asp:Label ID="lblResp003" runat="server" Text="" Visible="false"></asp:Label></label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <br />
                                            <asp:UpdatePanel ID="upR4" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:RadioButton runat="server" ID="radioR4" GroupName="radioA" AutoPostBack="True" />
                                                    <label for="radioR4">
                                                        <asp:Label ID="lblRespuesta004" runat="server" Text=""></asp:Label><asp:Label ID="lblResp004" runat="server" Text="" Visible="false"></asp:Label></label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <br />
                                        </div>
                                    </div>

                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Button CssClass="btn btn-secondary" aling="right" ID="btnGuardaRespuesta" runat="server" Text="Guardar" TabIndex="18" OnClick="btnGuardaRespuesta_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true">
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
                <asp:UpdatePanel ID="upResultado" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="container-fluid" id="divResultado" runat="server" visible="false">
                            <div class="card">
                                <div class="card-body">
                                    <h5 runat="server" id="H1" title="uno">
                                        <asp:Label ID="lblResultado" CssClass="modal-title" runat="server" Text=""></asp:Label>
                                    </h5>
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-6 col-md-12 col-lg-12">
                                            <div class="card rounded-0 p-0 shadow-sm">
                                                <div class="table-responsive">
                                                    <asp:GridView
                                                        CssClass="table table-bordered table-condensed"
                                                        ID="gvResultados"
                                                        runat="server"
                                                        AutoGenerateColumns="False"
                                                        AllowPaging="True"
                                                        CellPadding="3"
                                                        ForeColor="Black"
                                                        GridLines="Vertical"
                                                        TabIndex="5"
                                                        BackColor="White"
                                                        BorderColor="#999999"
                                                        BorderStyle="Solid"
                                                        BorderWidth="1px"
                                                        PageSize="20"
                                                        Font-Size="Smaller"
                                                        AllowSorting="True">

                                                        <AlternatingRowStyle BackColor="#bcbdc1" />
                                                        <Columns>

                                                            <asp:BoundField DataField="MateriaTemaPregunta" HeaderText="Pregunta" SortExpression="MateriaTemaPregunta" Visible="true" />

                                                            <asp:BoundField DataField="MateriaTemaPreguntaRespuesta" HeaderText="Respuesta" SortExpression="MateriaTemaPreguntaRespuesta" ItemStyle-HorizontalAlign="Justify">

                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />

                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="Respuesta" HeaderText="Estatus" SortExpression="Respuesta" Visible="true" DataFormatString="{0:$ 0,0.000000}">
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Justificacion" HeaderText="Justificacion" SortExpression="Justificacion" Visible="true" DataFormatString="{0:$ 0,0.000000}">
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#bcbdc1" />
                                                        <HeaderStyle BackColor="#797a7c" ForeColor="White" Font-Bold="false" />
                                                        <PagerSettings FirstPageText="Inicio" LastPageText="Final" />
                                                        <PagerStyle BackColor="#bcbdc1" ForeColor="Black" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#bcbdc1" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#bcbdc1" />
                                                        <SortedAscendingHeaderStyle BackColor="#bcbdc1" />
                                                        <SortedDescendingCellStyle BackColor="#bcbdc1" />
                                                        <SortedDescendingHeaderStyle BackColor="#bcbdc1" />
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="upUsuario" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="card" runat="server" id="cardUsuario" visible="false">
                            <div class="card-header bg-secondary">

                                <div class="input-group">
                                    <asp:LinkButton ID="lkbUsuarioAgregar" CssClass="btn btn-light" runat="server" TabIndex="1" OnClick="lkbUsuarioAgregar_Click">
                                                                   Agregar <i class="fas fa-user-plus text-secondary fa-lg"></i>
                                    </asp:LinkButton>
                                    &nbsp;
                                                <asp:LinkButton ID="lkbUsuarioEdita" CssClass="btn btn-light" runat="server" TabIndex="2" OnClick="lkbUsuarioEdita_Click">
                                                                   Editar <i class="fas fa-user-edit text-secondary fa-lg"></i>
                                                </asp:LinkButton>
                                </div>
                                <br />
                                <div class="input-group" runat="server" id="divBuscaUsuario" visible="false">

                                    <div class="form-group">
                                        <asp:DropDownList CssClass="form-control input-box" ID="sBusquedaUsuario" runat="server" TabIndex="3" required="required" AutoPostBack="true"></asp:DropDownList>
                                    </div>

                                    <asp:TextBox CssClass="form-control" ID="iUsuarioBuscar" runat="server" placeholder="*Buscar" TextMode="Search" TabIndex="4" onkeyup="this.value = this.value.toUpperCase();" required="required"></asp:TextBox>

                                    <ajaxtoolkit:autocompleteextender id="aceUsuarioBuscar" runat="server" servicemethod="busca_pnl" minimumprefixlength="2" completioninterval="100" enablecaching="true" completionsetcount="10" targetcontrolid="iUsuarioBuscar" firstrowselected="false"></ajaxtoolkit:autocompleteextender>
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID="lkbUsuarioBuscar" runat="server" CssClass="btn btn-light  form-control" TabIndex="5">
                                                                    <i class="fas fa-search text-secondary fa-lg"></i>
                                        </asp:LinkButton>
                                    </span>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="table-responsive">
                                        <asp:GridView CssClass="table table-bordered table-condensed" ID="gvUsuarios" runat="server" RowStyle-VerticalAlign="Middle" AutoGenerateColumns="False" AllowPaging="True" CellPadding="3" ForeColor="Black" GridLines="Vertical" TabIndex="5" PageSize="5" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" HeaderStyle-CssClass="GridHeader">
                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                                            <Columns>
                                                <asp:BoundField DataField="UsuarioID" HeaderText="ID" SortExpression="UsuarioID" Visible="true" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                                                    <HeaderStyle CssClass="hideGridColumn"></HeaderStyle>

                                                    <ItemStyle CssClass="hideGridColumn"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CodigoUsuario" HeaderText="ID" SortExpression="CodigoUsuario" Visible="true" HeaderStyle-CssClass="align-content-center">

                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nom_comp" HeaderText="NOMBRE COMPLETO" SortExpression="nom_comp">

                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FechaRegistro" HeaderText="REGISTRO" SortExpression="FechaRegistro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false">

                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="ESTATUS">
                                                    <ItemTemplate>
                                                        <asp:DropDownList class="form-control" ID="ddlEstatusUsuarioID" runat="server">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton CssClass="" ID="LinkButton1" runat="server" CommandName="cnInformacionUsuario" ToolTip="Información de Usuario">
                                            <i class="fas fa-info text-secondary fa-lg"></i>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton CssClass="" ID="LinkButton2" runat="server" ToolTip="Guarda cambios de Información de Usuario">
                                            <i class="fas fa-save text-secondary fa-lg"></i>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton CssClass="" ID="LinkButton3" runat="server">
                                            <i class="fas fa-user-shield text-secondary fa-lg"></i>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCCCC" />
                                            <HeaderStyle BackColor="#dc3545" ForeColor="White" Font-Bold="false" />
                                            <PagerSettings FirstPageText="Inicio" LastPageText="Final" />
                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#000099" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#808080" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#383838" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <br />
                                <div runat="server" id="divDatosUsuario" visible="false">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:DropDownList CssClass="form-control input-box" ID="sTipoUsuario" runat="server" TabIndex="6" required="required" AutoPostBack="true" ></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <select class="form-control" runat="server" id="sPerfilUsuario" tabindex="7" required="required">
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <select class="form-control" runat="server" id="sGeneroUsuario" tabindex="8" required="required">
                                                </select>
                                            </div>
                                        </div>

                                        <div class="form-group col-md-2">
                                            <input type="date" class="form-control" runat="server" id="iNacimientoUsuario" required="required" placeholder="Fecha de Nacimiento" tabindex="9" value="null" />
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-group col-md-4">
                                            <input type="text" class="form-control" runat="server" id="iNombresUsuario" required="required" placeholder="Nombre(s)" tabindex="10" onkeyup="this.value = this.value.toUpperCase();" />
                                        </div>
                                        <div class="form-group col-md-4">
                                            <input type="text" class="form-control" runat="server" id="iApaternoUsuario" required="required" placeholder="Apellido Paterno" tabindex="11" onkeyup="this.value = this.value.toUpperCase();" />
                                        </div>
                                        <div class="form-group col-md-4">
                                            <input type="text" class="form-control" runat="server" id="iAmaternoUsuario" required="required" placeholder="Apellido Materno" tabindex="12" onkeyup="this.value = this.value.toUpperCase();" />
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="form-group col-md-3">
                                            <input type="email" class="form-control" runat="server" id="iEmailPersonalUsuario" placeholder="Correo Personal" tabindex="13" required="required" />
                                        </div>
                                        <div class="form-group col-md-2">
                                            <asp:Button CssClass="btn btn-secondary form-control" ID="btnControlUsuario" runat="server" Text="Generar datos de control" TabIndex="14" />
                                        </div>
                                        <div class="form-group col-md-2">
                                            <input type="text" class="form-control" runat="server" id="iUsuario" required="required" placeholder="Usuario" tabindex="15" disabled="disabled" />
                                        </div>

                                        <div class="form-group col-md-2">
                                            <input type="password" class="form-control" runat="server" id="iClave" required="required" placeholder="Contraseña" tabindex="16" disabled="disabled" />
                                        </div>
                                        <div class="form-group col-md-3">
                                            <input type="email" class="form-control" runat="server" id="iEmailCorporativoUsuario" required="required" placeholder="Correo Corporativo" tabindex="17" disabled="disabled" />
                                        </div>
                                    </div>

                                    <div class="row">
                                    </div>
                                    <asp:Button CssClass="btn btn-secondary" ID="btnUsuarioG" runat="server" Text="Guardar" TabIndex="18" Enabled="false" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
                     </div>
            </main>

            <!-- page-content" -->
        </div>
        <div class="modal" id="myModal">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
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
