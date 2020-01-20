<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="webAI_UNAM.Default" %>

<!DOCTYPE html>
<html lang="es-mx">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Aula / Intelimundo</title>
    <meta name="description" content="Free Bootstrap Theme by BootstrapMade.com">
    <meta name="keywords" content="free website templates, free bootstrap themes, free template, free bootstrap, free website template">

       <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Open+Sans|Candal|Alegreya+Sans">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous" />
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="css/imagehover.min.css">
    <link rel="stylesheet" type="text/css" href="css/style.css">
    <link href="Estilos/Video.css" rel="stylesheet" />
    <script async data-id="22292" src="https://cdn.widgetwhats.com/script.min.js"></script>
</head>

<body>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!--Navigation bar-->
        <nav class="navbar navbar-default navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="#banner">Inteli<span>mundo</span></a>
                </div>
                <div class="collapse navbar-collapse" id="myNavbar">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="#feature">Caracteristicas</a></li>
                        <li><a href="#organisations">Organización</a></li>
                        <li><a href="#courses">Cursos</a></li>
                        <li><a href="#pricing">Precios</a></li>
                        <li><a href="PreRegistro.aspx">Pre-Registro</a></li>
                        <li class="btn-trial"><a href="#" data-target="#login" data-toggle="modal">Iniciar Sesión</a></li>
                    </ul>
                </div>
            </div>
        </nav>
        <!--/ Navigation bar-->
        <!--Modal box-->

        <div class="modal fade" id="login" role="dialog">
            <div class="modal-dialog modal-sm">

                <!-- Modal content no 1-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <div class="text-center">

                            <img class="img-responsive img-thumbnail" src="Imagenes/im.png" width="128" />
                        </div>

                    </div>
                    <div class="modal-body padtrbl">

                        <div class="login-box-body">
                            <p class="login-box-msg">Inicia sesión para comenzar</p>
                            <div class="form-group">

                                <div class="form-group has-feedback">
                                    <!----- username -------------->
                                    <input class="form-control" runat="server" placeholder="Username" id="loginid" type="text" required />
                                    <span style="display: none; font-weight: bold; position: absolute; color: #f6d738; position: absolute; padding: 4px; font-size: 11px; background-color: rgba(128, 128, 128, 0.26); z-index: 17; right: 27px; top: 5px;" id="span_loginid"></span>
                                    <!---Alredy exists  ! -->
                                    <span class=" form-control-feedback"><i class="fas fa-user-lock" style="color: #f6d738"></i></span>
                                </div>
                                <div class="form-group has-feedback">
                                    <!----- password -------------->
                                    <input class="form-control" runat="server" placeholder="Password" id="loginpsw" type="password" autocomplete="off" required />
                                    <span style="display: none; font-weight: bold; position: absolute; color: grey; position: absolute; padding: 4px; font-size: 11px; background-color: rgba(128, 128, 128, 0.26); z-index: 17; right: 27px; top: 5px;" id="span_loginpsw"></span>
                                    <!---Alredy exists  ! -->
                                    <span class=" form-control-feedback"><i class="fas fa-key" style="color: #f6d738"></i></span>
                                </div>
                                <div class="row">

                                    <div class="col-xs-12">
                                        <asp:Button CssClass="btn btn-green btn-block btn-flat" ID="btn_acceso" runat="server" Text="Iniciar sesión" TabIndex="3" OnClick="Button1_Click" />
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <!--/ Modal box-->
        <header>
            <div class="overlay"></div>
            <video playsinline="playsinline" autoplay="autoplay" muted="muted" loop="loop">
                <source src="Material/PROMO INTELIMINDO.mp4" type="video/mp4">
            </video>
            <div class="container h-100">
                <div class="d-flex h-100 text-center align-items-center">
                    <div class="w-100 text-white">
                    </div>
                </div>
            </div>
        </header>
        <!--Feature-->
        <section id="feature" class="section-padding">
            <div class="container">
                <div class="row">
                    <div class="header-section text-center">
                        <h2>Caracteristicas</h2>

                        <hr class="bottom-line">
                    </div>
                    <div class="feature-info">
                        <div class="fea">
                            <div class="col-md-3">
                                <div class="heading pull-right">
                                    <h4>¡Viaja con tu aula!</h4>
                                    <p>Accede desde cualquier parte del mundo tan sólo necesitas un dispositivo con conexión a Internet.</p>
                                </div>
                                <div class="fea-img pull-left">
                                    <i class="fas fa-suitcase-rolling"></i>
                                </div>
                            </div>
                        </div>
                        <div class="fea">
                            <div class="col-md-3">
                                <div class="heading pull-right">
                                    <h4>¡Nosotros te ayudamos!</h4>
                                    <p>Tienes dudas o necesitas apoyo, te apoyamos a través de foros o chat en línea, estamos al pendiente de ti.</p>
                                </div>
                                <div class="fea-img pull-left">
                                    <i class="fas fa-hands-helping"></i>
                                </div>
                            </div>
                        </div>
                        <div class="fea">
                            <div class="col-md-3">
                                <div class="heading pull-right">
                                    <h4>¡Contenido clasificado!</h4>
                                    <p>Por áreas del conocimiento, escuelas y nivel académico, elige la más adecuada para tu preparación.</p>
                                </div>
                                <div class="fea-img pull-left">
                                    <i class="fas fa-certificate"></i>
                                </div>
                            </div>
                        </div>
                        <div class="fea">
                            <div class="col-md-3">
                                <div class="heading pull-right">
                                    <h4>¡Libera tu horario!</h4>
                                    <p>El aula está a tu disposición las 24/7, decide cuando programarás tus horarios de estudio.</p>
                                </div>
                                <div class="fea-img pull-left">
                                    <i class="fas fa-user-clock"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--/ feature-->
        <!--Organisations-->
        <section id="organisations" class="section-padding">
            <div class="container">
                <div class="row">
                    <div class="col-md-6">
                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                            <div class="orga-stru">
                                <h3>65%</h3>
                                <p>Say NO!!</p>
                                <i class="fa fa-male"></i>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                            <div class="orga-stru">
                                <h3>20%</h3>
                                <p>Says Yes!!</p>
                                <i class="fa fa-male"></i>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                            <div class="orga-stru">
                                <h3>15%</h3>
                                <p>Can't Say!!</p>
                                <i class="fa fa-male"></i>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="detail-info">
                            <hgroup>
                                <h3 class="det-txt">¿Es educación de Calidad, Inclusiva y accesible?</h3>
                                <h4 class="sm-txt">(Revised and Updated for 2016)</h4>
                            </hgroup>
                            <p class="det-p">Donec et lectus bibendum dolor dictum auctor in ac erat. Vestibulum egestas sollicitudin metus non urna in eros tincidunt convallis id id nisi in interdum.</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--/ Organisations-->
        <!--Cta-->
        <section id="cta-2">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <h2 class="text-center">Subscribe Now</h2>
                        <p class="cta-2-txt">Sign up for our free weekly software design courses, we’ll send them right to your inbox.</p>
                        <div class="cta-2-form text-center">
                            <form action="#" method="post" id="workshop-newsletter-form">
                                <input name="" placeholder="Enter Your Email Address" type="email">
                                <input class="cta-2-form-submit-btn" value="Subscribe" type="submit">
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--/ Cta-->
        <!--work-shop-->
        <section id="work-shop" class="section-padding">
            <div class="container">
                <div class="row">
                    <div class="header-section text-center">
                        <h2>Ingreso a Universidad</h2>
                        <p>Preparación de Exámenes Aula Digital </p>
                        <hr class="bottom-line">
                    </div>
                    <div class="col-md-4 col-sm-6">
                        <div class="service-box text-center">
                            <div class="icon-box">
                                <i class="fa fa-html5 color-green"></i>
                            </div>
                            <div class="icon-text">
                                <h4 class="ser-text">UAM</h4>
                                <p>Considerado uno de los exámenes más complejos para ingreso a la universidad. ¡Este es el curso que necesitas para cumplir con esta demanda. </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6">
                        <div class="service-box text-center">
                            <div class="icon-box">
                                <i class="fa fa-css3 color-green"></i>
                            </div>
                            <div class="icon-text">
                                <h4 class="ser-text">UNAM</h4>
                                <p>Tan sólo 1 de cada 10 aspirantes pueden matricularse en esta universidad. ¿Tienes lo necesario para ingresar? Este curso es para ti.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6">
                        <div class="service-box text-center">
                            <div class="icon-box">
                                <i class="fa fa-joomla color-green"></i>
                            </div>
                            <div class="icon-text">
                                <h4 class="ser-text">IPN</h4>
                                <p>Si tu decisión es ingresar a esta universidad, en este curso podrás encontrar las materias necesarias para estudiar y además preguntas de cada área de estudio para facilitarlo. </p>
                            </div>
                        </div>
                    </div>
                    <div class="header-section text-center">
                        <br>
                        <h2>Ingreso a Media Superior</h2>
                        <hr class="bottom-line">
                        <h2>Ingreso a Secundaria</h2>
                        <hr class="bottom-line">
                    </div>
                </div>
            </div>
        </section>
        <!--/ work-shop-->
        <!--Faculity member-->
        <section id="faculity-member" class="section-padding">
            <div class="container">
                <div class="row">
                    <div class="header-section text-center">
                        <h2>Meet Our Faculty Member</h2>
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Exercitationem nesciunt vitae,<br>
                            maiores, magni dolorum aliquam.
                        </p>
                        <hr class="bottom-line">
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <div class="pm-staff-profile-container">
                            <div class="pm-staff-profile-image-wrapper text-center">
                                <div class="pm-staff-profile-image">
                                    <img src="img/logo-web.png" alt="" class="img-thumbnail img-circle" />
                                </div>
                            </div>
                            <div class="pm-staff-profile-details text-center">
                                <p class="pm-staff-profile-name">Bryan Johnson</p>
                                <p class="pm-staff-profile-title">Lead Software Engineer</p>

                                <p class="pm-staff-profile-bio">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec et placerat dui. In posuere metus et elit placerat tristique. Maecenas eu est in sem ullamcorper tincidunt. </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <div class="pm-staff-profile-container">
                            <div class="pm-staff-profile-image-wrapper text-center">
                                <div class="pm-staff-profile-image">
                                    <img src="img/logo-web.png" alt="" class="img-thumbnail img-circle" />
                                </div>
                            </div>
                            <div class="pm-staff-profile-details text-center">
                                <p class="pm-staff-profile-name">Bryan Johnson</p>
                                <p class="pm-staff-profile-title">Lead Software Engineer</p>

                                <p class="pm-staff-profile-bio">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec et placerat dui. In posuere metus et elit placerat tristique. Maecenas eu est in sem ullamcorper tincidunt. </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <div class="pm-staff-profile-container">
                            <div class="pm-staff-profile-image-wrapper text-center">
                                <div class="pm-staff-profile-image">
                                    <img src="img/logo-web.png" alt="" class="img-thumbnail img-circle" />
                                </div>
                            </div>
                            <div class="pm-staff-profile-details text-center">
                                <p class="pm-staff-profile-name">Bryan Johnson</p>
                                <p class="pm-staff-profile-title">Lead Software Engineer</p>

                                <p class="pm-staff-profile-bio">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec et placerat dui. In posuere metus et elit placerat tristique. Maecenas eu est in sem ullamcorper tincidunt. </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--/ Faculity member-->
        <!--Testimonial-->
        <section id="testimonial" class="section-padding">
            <div class="container">
                <div class="row">
                    <div class="header-section text-center">
                        <h2 class="white">See What Our Customer Are Saying?</h2>
                        <p class="white">
                            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Exercitationem nesciunt vitae,<br>
                            maiores, magni dolorum aliquam.
                        </p>
                        <hr class="bottom-line bg-white">
                    </div>
                    <div class="col-md-6 col-sm-6">
                        <div class="text-comment">
                            <p class="text-par">"Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, nec sagittis sem"</p>
                            <p class="text-name">Abraham Doe - Creative Dırector</p>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6">
                        <div class="text-comment">
                            <p class="text-par">"Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, nec sagittis sem"</p>
                            <p class="text-name">Abraham Doe - Creative Dırector</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--/ Testimonial-->
        <!--Courses-->
        <section id="courses" class="section-padding">
            <div class="container">
                <div class="row">
                    <div class="header-section text-center">
                        <h2>Courses</h2>
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Exercitationem nesciunt vitae,<br>
                            maiores, magni dolorum aliquam.
                        </p>
                        <hr class="bottom-line">
                    </div>
                </div>
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-md-4 col-sm-6 padleft-right">
                        <figure class="imghvr-fold-up">
                            <img src="img/course01.jpg" class="img-responsive">
                            <figcaption>
                                <h3>Course Name</h3>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Magnam atque, nostrum veniam consequatur libero fugiat, similique quis.</p>
                            </figcaption>
                            <a href="#"></a>
                        </figure>
                    </div>
                    <div class="col-md-4 col-sm-6 padleft-right">
                        <figure class="imghvr-fold-up">
                            <img src="img/course02.jpg" class="img-responsive">
                            <figcaption>
                                <h3>Course Name</h3>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Magnam atque, nostrum veniam consequatur libero fugiat, similique quis.</p>
                            </figcaption>
                            <a href="#"></a>
                        </figure>
                    </div>
                    <div class="col-md-4 col-sm-6 padleft-right">
                        <figure class="imghvr-fold-up">
                            <img src="img/course03.jpg" class="img-responsive">
                            <figcaption>
                                <h3>Course Name</h3>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Magnam atque, nostrum veniam consequatur libero fugiat, similique quis.</p>
                            </figcaption>
                            <a href="#"></a>
                        </figure>
                    </div>
                    <div class="col-md-4 col-sm-6 padleft-right">
                        <figure class="imghvr-fold-up">
                            <img src="img/course04.jpg" class="img-responsive">
                            <figcaption>
                                <h3>Course Name</h3>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Magnam atque, nostrum veniam consequatur libero fugiat, similique quis.</p>
                            </figcaption>
                            <a href="#"></a>
                        </figure>
                    </div>
                    <div class="col-md-4 col-sm-6 padleft-right">
                        <figure class="imghvr-fold-up">
                            <img src="img/course05.jpg" class="img-responsive">
                            <figcaption>
                                <h3>Course Name</h3>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Magnam atque, nostrum veniam consequatur libero fugiat, similique quis.</p>
                            </figcaption>
                            <a href="#"></a>
                        </figure>
                    </div>
                    <div class="col-md-4 col-sm-6 padleft-right">
                        <figure class="imghvr-fold-up">
                            <img src="img/course06.jpg" class="img-responsive">
                            <figcaption>
                                <h3>Course Name</h3>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Magnam atque, nostrum veniam consequatur libero fugiat, similique quis.</p>
                            </figcaption>
                            <a href="#"></a>
                        </figure>
                    </div>
                </div>
            </div>
        </section>
        <!--/ Courses-->
        <!--Pricing-->
        <section id="pricing" class="section-padding">
            <div class="container">
                <div class="row">
                    <div class="header-section text-center">
                        <h2>Our Pricing</h2>
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Exercitationem nesciunt vitae,<br>
                            maiores, magni dolorum aliquam.
                        </p>
                        <hr class="bottom-line">
                    </div>
                    <div class="col-md-4 col-sm-4">
                        <div class="price-table">
                            <!-- Plan  -->
                            <div class="pricing-head">
                                <h4>Monthly Plan</h4>
                                <span class="fa fa-usd curency"></span><span class="amount">200</span>
                            </div>

                            <!-- Plean Detail -->
                            <div class="price-in mart-15">
                                <a href="#" class="btn btn-bg green btn-block">PURCHACE</a>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-4">
                        <div class="price-table">
                            <!-- Plan  -->
                            <div class="pricing-head">
                                <h4>Quarterly Plan</h4>
                                <span class="fa fa-usd curency"></span><span class="amount">800</span>
                            </div>

                            <!-- Plean Detail -->
                            <div class="price-in mart-15">
                                <a href="#" class="btn btn-bg yellow btn-block">PURCHACE</a>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-4">
                        <div class="price-table">

                            <!-- Plan  -->
                            <div class="pricing-head">
                                <h4>Year Plan</h4>
                                <span class="fa fa-usd curency"></span><span class="amount">1200</span>
                            </div>

                            <!-- Plean Detail -->
                            <div class="price-in mart-15">
                                <a href="#" class="btn btn-bg red btn-block">PURCHACE</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--/ Pricing-->
        <!--Contact-->
        <section id="contact" class="section-padding">
            <div class="container">
                <div class="row">
                    <div class="header-section text-center">
                        <h2>Contact Us</h2>
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Exercitationem nesciunt vitae,<br>
                            maiores, magni dolorum aliquam.
                        </p>
                        <hr class="bottom-line">
                    </div>
                    <div id="sendmessage">Your message has been sent. Thank you!</div>
                    <div id="errormessage"></div>
                    <form action="" method="post" role="form" class="contactForm">
                        <div class="col-md-6 col-sm-6 col-xs-12 left">
                            <div class="form-group">
                                <input type="text" name="name" class="form-control form" id="name" placeholder="Your Name" data-rule="minlen:4" data-msg="Please enter at least 4 chars" />
                                <div class="validation"></div>
                            </div>
                            <div class="form-group">
                                <input type="email" class="form-control" name="email" id="email" placeholder="Your Email" data-rule="email" data-msg="Please enter a valid email" />
                                <div class="validation"></div>
                            </div>
                            <div class="form-group">
                                <input type="text" class="form-control" name="subject" id="subject" placeholder="Subject" data-rule="minlen:4" data-msg="Please enter at least 8 chars of subject" />
                                <div class="validation"></div>
                            </div>
                        </div>

                        <div class="col-md-6 col-sm-6 col-xs-12 right">
                            <div class="form-group">
                                <textarea class="form-control" name="message" rows="5" data-rule="required" data-msg="Please write something for us" placeholder="Message"></textarea>
                                <div class="validation"></div>
                            </div>
                        </div>

                        <div class="col-xs-12">
                            <!-- Button -->
                            <button type="submit" id="submit" name="submit" class="form contact-form-button light-form-button oswald light">SEND EMAIL</button>
                        </div>
                    </form>

                </div>
            </div>
        </section>
        <!--/ Contact-->
        <!--Footer-->
        <footer id="footer" class="footer">
            <div class="container text-center">

                <h3>Start Your Free Trial Now!</h3>

                <form class="mc-trial row">
                    <div class="form-group col-md-3 col-md-offset-2 col-sm-4">
                        <div class=" controls">
                            <input name="name" placeholder="Enter Your Name" class="form-control" type="text">
                        </div>
                    </div>
                    <!-- End email input -->
                    <div class="form-group col-md-3 col-sm-4">
                        <div class=" controls">
                            <input name="EMAIL" placeholder="Enter Your email" class="form-control" type="email">
                        </div>
                    </div>
                    <!-- End email input -->
                    <div class="col-md-2 col-sm-4">
                        <p>
                            <button name="submit" type="submit" class="btn btn-block btn-submit">
                                Submit <i class="fa fa-arrow-right"></i>
                            </button>
                        </p>
                    </div>
                </form>
                <!-- End newsletter-form -->
                <ul class="social-links">
                    <li><a href="#link"><i class="fa fa-twitter fa-fw"></i></a></li>
                    <li><a href="#link"><i class="fa fa-facebook fa-fw"></i></a></li>
                    <li><a href="#link"><i class="fa fa-google-plus fa-fw"></i></a></li>
                    <li><a href="#link"><i class="fa fa-dribbble fa-fw"></i></a></li>
                    <li><a href="#link"><i class="fa fa-linkedin fa-fw"></i></a></li>
                </ul>
                ©2019. Todos los derechos reservados
      <div class="credits">
          Diseñada por <a href="#">intelimundo</a>
      </div>
            </div>
        </footer>
        <!--/ Footer-->
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
        <script src="js/jquery.min.js"></script>
        <script src="js/jquery.easing.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/custom.js"></script>
        <script src="contactform/contactform.js"></script>
        
    </form>
</body>

</html>

