using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webAI_UNAM
{
    public partial class Panel : System.Web.UI.Page
    {
        public static Guid empf_ID = Guid.Empty, usr_ID = Guid.Empty;
        public static int FiltroMateriaID = 0, OrdenMateriaTemaID = 0, FiltroMateriaTemaID = 0, FiltroMateriaTemaPreguntaID = 0, FiltroPreguntaDiagnostico = 0, FiltroPreguntaTest = 0, FiltroPreguntaID = 0, FiltroPreguntaIDc = 0;
        public static DataSet ds;
        public static DataTable dtPreguntasDiagnostico, dtRespuestasDiagnostico, dtPreguntasCuestionario, dtRespuestasCuestionario;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    try
                    {
                        UsuarioFiltrado();
                        DatosMateriasTemas();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("Default.aspx");
            }
        }

        private void DatosMateriasTemas()
        {
            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var iModelo = (from t1 in Modelo.catMateria select t1).ToList();

                int EstatusMAteria = 0;
                int Materia001TD = 0;
                int Materia001TC = 0;
                string Materia001D;
                string Materia001C;

                int AC = 0;
                int AP = 0;

                foreach (var fModelo in iModelo)
                {
                    switch (fModelo.MateriaID)
                    {
                        case 1:

                            lblMateria001.Text = fModelo.Materia;

                            upMateria0001.Update();

                            break;

                        case 2:

                            lblMateria002.Text = fModelo.Materia;

                            upMateria0002.Update();

                            using (imDesarrolloEntities mRespuestas = new imDesarrolloEntities())
                            {
                                var iRespuestas = (from i_u in mRespuestas.tblPreguntasRespuestas(2, usr_ID)
                                                   select i_u).ToList();

                                if (iRespuestas.Count == 0)
                                {
                                    Materia001TD = 0;
                                    Materia001TC = 0;
                                }
                                else
                                {
                                    Materia001TD = iRespuestas[0].DiagnoticoP.Value;
                                    Materia001TC = iRespuestas[0].CuestionarioP.Value;

                                    AC = AC + Materia001TC;
                                }
                            }
                            Materia001D = "width: " + Materia001TD.ToString() + "%";

                            divMat002D.Attributes["style"] = Materia001D;
                            lblMat002D.Text = Materia001D.Replace("width: ", "");

                            Materia001C = "width: " + Materia001TC.ToString() + "%";

                            divMat002C.Attributes["style"] = Materia001C;
                            lblMat002C.Text = Materia001C.Replace("width: ", "");

                            if (EstatusMAteria == 10)
                            {
                                iM002.Attributes["style"] = "color: green";
                                upMateria0002.Update();
                            }

                            break;

                        case 10:

                            lblMateria010.Text = fModelo.Materia;

                            upMateria0010.Update();

                            using (imDesarrolloEntities mRespuestas = new imDesarrolloEntities())
                            {
                                var iRespuestas = (from i_u in mRespuestas.tblPreguntasRespuestas(2, usr_ID)
                                                   select i_u).ToList();

                                if (iRespuestas.Count == 0)
                                {
                                    Materia001TD = 0;
                                    Materia001TC = 0;
                                }
                                else
                                {
                                    Materia001TD = iRespuestas[0].DiagnoticoP.Value;
                                    Materia001TC = iRespuestas[0].CuestionarioP.Value;

                                    AC = AC + Materia001TC;
                                }
                            }
                            Materia001D = "width: " + Materia001TD.ToString() + "%";

                            divMat002D.Attributes["style"] = Materia001D;
                            lblMat002D.Text = Materia001D.Replace("width: ", "");

                            Materia001C = "width: " + Materia001TC.ToString() + "%";

                            divMat002C.Attributes["style"] = Materia001C;
                            lblMat002C.Text = Materia001C.Replace("width: ", "");

                            if (EstatusMAteria == 10)
                            {
                                iM002.Attributes["style"] = "color: green";
                                upMateria0002.Update();
                            }

                            break;

                        default:
                            break;
                    }
                }

                divAC.Attributes["style"] = ((AC * 100) / 1000).ToString() + "%";

                lblAC.Text = ((AC * 100) / 1000).ToString() + "%";
            }
        }

        private void UsuarioFiltrado()
        {
            try
            {
                usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);

                using (db_imEntities m_usuario = new db_imEntities())
                {
                    var i_usuario = (from i_u in m_usuario.inf_usuario
                                     join i_up in m_usuario.inf_usr_personales on i_u.usuario_ID equals i_up.usuario_ID
                                     join i_uh in m_usuario.inf_usr_rh on i_u.usuario_ID equals i_uh.usuario_ID
                                     join i_pu in m_usuario.fact_perfil on i_uh.perfil_ID equals i_pu.perfil_ID

                                     where i_u.usuario_ID == usr_ID
                                     select new
                                     {
                                         i_u.usuario_ID,
                                         i_u.cod_usr,
                                         i_up.nombres,
                                         i_up.apaterno,
                                         i_up.amaterno,
                                         i_pu.perfil_desc,
                                         i_pu.perfil_ID,
                                     }).FirstOrDefault();

                    lblNombreUsuario.Text = i_usuario.nombres;
                    lblNombreApellidos.Text = i_usuario.apaterno + " " + i_usuario.amaterno;
                    lbl_EstatusUsuario.Text = "Conectad@";
                    i_EstatusUsuario.Attributes["style"] = "color: green";
                }
            }
            catch
            {
                Response.Redirect("acceso.aspx");
            }
        }

        #region Materia0001

        protected void lkbMateria0001_Click(object sender, EventArgs e)
        {
            divResultado.Visible = false;
            divPreguntas.Visible = false;
            divComentario.Visible = false;
            divTema.Visible = false;
            divDiagnostico.Visible = false;

            divContainer.Visible = true;
            upContainer.Update();
        }

        protected void lkbMateria0001Tema0001_Click(object sender, EventArgs e)
        {
        }

        #endregion Materia0001

        #region Materia0002

        protected void lkbMateria0002Tema0001_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 2;
            Session["OMatID"] = 1;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema1/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema1/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema1/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0002Tema0002_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 2;
            Session["OMatID"] = 2;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema2/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema2/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema2/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0002Tema0003_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 2;
            Session["OMatID"] = 3;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tem3/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema3/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema3/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0002Tema0004_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 2;
            Session["OMatID"] = 4;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema4/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema4/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema4/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0002Tema0005_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 2;
            Session["OMatID"] = 5;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema5/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema5/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema5/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0002Tema0006_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 2;
            Session["OMatID"] = 6;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema6/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema6/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema6/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0002Tema0007_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 2;
            Session["OMatID"] = 7;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema7/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema7/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema7/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0002Tema0008_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 2;
            Session["OMatID"] = 8;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema8/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema8/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema8/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0002Tema0009_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 2;
            Session["OMatID"] = 9;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema9/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema9/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema9/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0002Tema0010_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 2;
            Session["OMatID"] = 10;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema10/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema10/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema10/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        #endregion Materia0002

        #region Materia0010

        protected void lkbMateria0010Tema0001_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 10;
            Session["OMatID"] = 1;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema1/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema1/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Quimica/Tema1/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0010Tema0002_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 10;
            Session["OMatID"] = 2;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema2/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema2/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Quimica/Tema2/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0010Tema0003_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 10;
            Session["OMatID"] = 3;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema3/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema3/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Quimica/Tema3/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0010Tema0004_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 10;
            Session["OMatID"] = 4;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema4/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema4/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Quimica/Tema4/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0010Tema0005_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 10;
            Session["OMatID"] = 5;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema5/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema5/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Quimica/Tema5/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0010Tema0006_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 10;
            Session["OMatID"] = 6;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema6/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema6/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Quimica/Tema6/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0010Tema0007_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 10;
            Session["OMatID"] = 7;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema7/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema7/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Quimica/Tema7/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0010Tema0008_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 10;
            Session["OMatID"] = 8;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema8/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema8/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Quimica/Tema8/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0010Tema0009_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 10;
            Session["OMatID"] = 9;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema9/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema9/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Quimica/Tema9/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0010Tema0010_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 10;
            Session["OMatID"] = 10;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema10/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema10/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Quimica/Tema10/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        protected void lkbMateria0010Tema0011_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();
            Session["FMatID"] = 10;
            Session["OMatID"] = 11;

            FiltroMateriaID = (int)(Session["FMatID"]);
            OrdenMateriaTemaID = (int)(Session["OMatID"]);

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                Session["FMatTemID"] = fModelo.MateriaTemaID;

                FiltroMateriaTemaID = (int)(Session["FMatTemID"]);

                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join c in Modelo.catMateriaTemaPregunta on a.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == FiltroMateriaID
                               where d.MateriaTemaID == FiltroMateriaTemaID
                               where a.UsuarioID == usr_ID

                               select a
                                   ).ToList();

                if (iModelo.Count == 0)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema11/VideoClase0001.mp4";
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = false;
                    divResultado.Visible = false;
                    divDiagnostico.Visible = false;
                    divPreguntas.Visible = false;
                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = true;
                    upPreguntas.Update();
                    upDiagnostico.Update();
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count <= 5)
                {
                    play_video.Visible = true;
                    play_video.Attributes["src"] = "Material/Universidad/Quimica/Tema11/VideoClase0001.mp4";
                    iframeTema.Attributes["src"] = "Material/Universidad/Quimica/Tema11/index.html";
                    iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                    upMateria0001Tema0001.Update();
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                    divResultado.Visible = false;
                    using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                    {
                        divComentario.Visible = false;

                        divPreguntas.Visible = true;

                        dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                        DataRow[] foundRows;
                        foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                        FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                        lblPregunta.Text = foundRows[0][1].ToString();

                        radioR1.Checked = false;
                        radioR2.Checked = false;
                        radioR3.Checked = false;
                        radioR4.Checked = false;

                        var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                           select c).ToList();

                        int f1 = 1;
                        foreach (var iResp in iRespuestaf)
                        {
                            string strlbl = "lblRespuesta00" + f1;

                            if (strlbl == "lblRespuesta001")
                            {
                                lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta002")
                            {
                                lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta003")
                            {
                                lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }

                            if (strlbl == "lblRespuesta004")
                            {
                                lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                            }
                            f1 += 1;
                        }
                        upPreguntas.Update();
                    }
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count >= 5 && iModelo.Count <= 10)
                {
                    divTema.Visible = true; divContainer.Visible = false;
                    lblPuntDiag.Text = "0";
                    divEbook.Visible = true;
                    divResultado.Visible = false;

                    divComentario.Visible = false;
                    comment1.Value = string.Empty;

                    lblPuntuacion.Text = "0";

                    btnDiagnostico.Visible = false;
                    upResultado.Update();
                    upTema.Update();
                }
                else if (iModelo.Count > 10)
                {
                    divEbook.Visible = false;
                    upComentario.Update();
                    divResultado.Visible = false;
                    upResultado.Update();
                    upResumen.Update();
                    divComentario.Visible = false;
                    divTema.Visible = false;
                    upTema.Update();
                    divContainer.Visible = true;
                    upContainer.Update();
                    iMateria0002Tema0001.Attributes["style"] = "color: green";
                    upMateria0002Tema0001.Update();
                }
            }
        }

        #endregion Materia0010

        #region Funciones

        protected void lkbResumen_Click(object sender, EventArgs e)
        {
            divDiagnostico.Visible = false;
            divEbook.Visible = false;
            divResultado.Visible = false;
            divComentario.Visible = false;
            upDiagnostico.Update();

            upResultado.Update();
            upComentario.Update();

            divContainer.Visible = true;
            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var iModelo = (from t1 in Modelo.catMateria select t1).ToList();

                int Materia001TD = 0;
                int Materia001TC = 0;
                string Materia001D;
                string Materia001C;

                int AC = 0;
                int AP = 0;

                foreach (var fModelo in iModelo)
                {
                    switch (fModelo.MateriaID)
                    {
                        case 1:

                            break;

                        case 2:

                            using (imDesarrolloEntities mRespuestas = new imDesarrolloEntities())
                            {
                                var iRespuestas = (from i_u in mRespuestas.tblPreguntasRespuestas(2, usr_ID)
                                                   select i_u).ToList();

                                if (iRespuestas.Count == 0)
                                {
                                    Materia001TD = 0;
                                    Materia001TC = 0;
                                }
                                else
                                {
                                    Materia001TD = iRespuestas[0].DiagnoticoP.Value;
                                    Materia001TC = iRespuestas[0].CuestionarioP.Value;

                                    AC = AC + Materia001TC;
                                }
                            }
                            Materia001D = "width: " + Materia001TD.ToString() + "%";

                            divMat002D.Attributes["style"] = Materia001D;
                            lblMat002D.Text = Materia001D.Replace("width: ", "");

                            Materia001C = "width: " + Materia001TC.ToString() + "%";

                            divMat002C.Attributes["style"] = Materia001C;
                            lblMat002C.Text = Materia001C.Replace("width: ", "");

                            break;

                        default:
                            break;
                    }
                }

                divAC.Attributes["style"] = ((AC * 100) / 1000).ToString() + "%";

                lblAC.Text = ((AC * 100) / 1000).ToString() + "%";
                upContainer.Update();
            }
        }

        private bool EstatusTemas(int MateriaID, int MateriaTemaID)
        {
            usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join b in Modelo.catMateriaTemaPreguntaRespuesta on a.MateriaTemaPreguntaRespuestaID equals b.MateriaTemaPreguntaRespuestaID
                               join c in Modelo.catMateriaTemaPregunta on b.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == MateriaID
                               where d.MateriaOrdenID == MateriaTemaID
                               where a.UsuarioID == usr_ID
                               where a.TipoPreguntaID == 2
                               select a
                                   ).ToList();
                if (iModelo.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private static DataTable GetTable(int MateriaIDFiltro, int MateriaTemaIDFiltro, int TipoPregunta)
        {
            DataTable dtff = new DataTable();

            dtff.Columns.Add("NuevoID", typeof(int));
            dtff.Columns.Add("Pregunta", typeof(string));
            dtff.Columns.Add("PreguntaID", typeof(int));

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var iModelo = (from c in Modelo.PreguntasSP(MateriaIDFiltro, MateriaTemaIDFiltro, TipoPregunta)
                               select c).ToList();

                foreach (var item in iModelo)
                {
                    DataRow row = dtff.NewRow();

                    row["Pregunta"] = item.MateriaTemaPregunta;
                    row["NuevoID"] = item.NuevoID;
                    row["PreguntaID"] = item.MateriaTemaPreguntaID;
                    dtff.Rows.Add(row);
                }
            }
            return dtff;
        }

        protected void btnDiagnostico_Click(object sender, EventArgs e)
        {
            btnDiagnostico.Visible = false;
            upGuardaDiagnostico.Update();

            dtPreguntasDiagnostico = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 1);

            DataRow[] foundRows;
            foundRows = dtPreguntasDiagnostico.Select("NuevoID = 1");

            FiltroPreguntaID = int.Parse(foundRows[0][2].ToString());
            divDiagnostico.Visible = true;
            lblTemaDiagnostico.Text = foundRows[0][1].ToString();

            rbRespDiag001.Checked = false;
            rbRespDiag002.Checked = false;
            rbRespDiag003.Checked = false;
            rbRespDiag004.Checked = false;

            using (imDesarrolloEntities mTema = new imDesarrolloEntities())
            {
                var iRespuesta = (from c in mTema.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaID)
                                  select c).ToList();

                int f1 = 1;
                foreach (var iResp in iRespuesta)
                {
                    string strlbl = "lblRespuesta00" + f1;

                    if (strlbl == "lblRespuesta001")
                    {
                        lblRespDiag001.Text = iResp.MateriaTemaPreguntaRespuesta;
                        lblRespDiagID001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                    }

                    if (strlbl == "lblRespuesta002")
                    {
                        lblRespDiag002.Text = iResp.MateriaTemaPreguntaRespuesta;
                        lblRespDiagID002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                    }

                    if (strlbl == "lblRespuesta003")
                    {
                        lblRespDiag003.Text = iResp.MateriaTemaPreguntaRespuesta;
                        lblRespDiagID003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                    }

                    if (strlbl == "lblRespuesta004")
                    {
                        lblRespDiag004.Text = iResp.MateriaTemaPreguntaRespuesta;
                        lblRespDiagID004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                    }
                    f1 += 1;
                }
            }

            upDiagnostico.Update();
        }

        protected void btnGuardaDiagnostico_Click(object sender, EventArgs e)
        {
            if (rbRespDiag001.Checked == false & rbRespDiag002.Checked == false & rbRespDiag003.Checked == false & rbRespDiag004.Checked == false)
            {
                Mensaje("Favor de seleccionar una opción");
            }
            else
            {
                string filtro;

                using (imDesarrolloEntities mTema = new imDesarrolloEntities())
                {
                    var iBitacora = (from a in mTema.catMateriaTemaPreguntaRespuestaBitacora
                                     where a.UsuarioID == usr_ID
                                     where a.TipoPreguntaID == 1
                                     select a
                                      ).ToList();

                    if (iBitacora.Count != 5)
                    {
                        if (rbRespDiag001.Checked == true || rbRespDiag002.Checked == true || rbRespDiag003.Checked == true || rbRespDiag004.Checked == true)
                        {
                            int intRespuesta = 0;
                            if (rbRespDiag001.Checked)
                            {
                                intRespuesta = int.Parse(lblRespDiagID001.Text);
                            }
                            else if (rbRespDiag002.Checked)
                            {
                                intRespuesta = int.Parse(lblRespDiagID002.Text);
                            }
                            else if (rbRespDiag003.Checked)
                            {
                                intRespuesta = int.Parse(lblRespDiagID003.Text);
                            }
                            else if (rbRespDiag004.Checked)
                            {
                                intRespuesta = int.Parse(lblRespDiagID004.Text);
                            }

                            var iRespuestaF = (from a in mTema.catMateriaTemaPreguntaRespuesta
                                               where a.MateriaTemaPreguntaRespuestaID == intRespuesta
                                               select a
                                                 ).FirstOrDefault();
                            var i_registro = new imDesarrolloEntities();
                            usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                            var dn_usr = new catMateriaTemaPreguntaRespuestaBitacora
                            {
                                TipoPreguntaID = 1,
                                UsuarioID = usr_ID,
                                MateriaTemaPreguntaRespuestaID = intRespuesta,
                                MateriaTemaPreguntaID = FiltroPreguntaID,
                                FechaRegistro = DateTime.Now
                            };

                            i_registro.catMateriaTemaPreguntaRespuestaBitacora.Add(dn_usr);

                            i_registro.SaveChanges();
                        }

                        var iBitacoraR = (from a in mTema.catMateriaTemaPreguntaRespuestaBitacora
                                          where a.UsuarioID == usr_ID
                                          where a.TipoPreguntaID == 1
                                          select a
                                      ).ToList();

                        FiltroPreguntaDiagnostico = iBitacoraR.Count;
                        FiltroPreguntaDiagnostico += 1;
                        try
                        {
                            filtro = "NuevoID = " + FiltroPreguntaDiagnostico.ToString();
                            DataRow[] foundRows;
                            foundRows = dtPreguntasDiagnostico.Select(filtro);
                            FiltroPreguntaID = int.Parse(foundRows[0][2].ToString());

                            lblTemaDiagnostico.Text = foundRows[0][1].ToString();
                            var iRespuesta = (from c in mTema.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaID)
                                              select c).ToList();
                            int f1 = 1;
                            foreach (var iResp in iRespuesta)
                            {
                                string strlbl = "lblRespuesta00" + f1;

                                if (strlbl == "lblRespuesta001")
                                {
                                    lblRespDiag001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                    lblRespDiagID001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                                }

                                if (strlbl == "lblRespuesta002")
                                {
                                    lblRespDiag002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                    lblRespDiagID002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                                }

                                if (strlbl == "lblRespuesta003")
                                {
                                    lblRespDiag003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                    lblRespDiagID003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                                }

                                if (strlbl == "lblRespuesta004")
                                {
                                    lblRespDiag004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                    lblRespDiagID004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                                }
                                f1 += 1;
                            }

                            rbRespDiag001.Checked = false;
                            rbRespDiag002.Checked = false;
                            rbRespDiag003.Checked = false;
                            rbRespDiag004.Checked = false;

                            upDiagnostico.Update();
                        }
                        catch (Exception)
                        {
                            usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                            var iMateria = (from a in mTema.catMateriaTemaPreguntaRespuestaBitacora
                                            join b in mTema.catMateriaTemaPreguntaRespuesta on a.MateriaTemaPreguntaRespuestaID equals b.MateriaTemaPreguntaRespuestaID
                                            join c in mTema.catMateriaTemaPregunta on b.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                                            join d in mTema.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                                            where a.TipoPreguntaID == 1
                                            where b.Respuesta == true
                                            where a.UsuarioID == usr_ID
                                            where d.MateriaTemaID == FiltroMateriaTemaID
                                            where d.MateriaID == FiltroMateriaID

                                            select a).ToList();

                            int intPunt = iMateria.Count;
                            int intCal = (intPunt * 2);

                            if (FiltroMateriaID == 1)
                            {
                                int MatTemaID = FiltroMateriaTemaID;

                                switch (MatTemaID)
                                {
                                    case 1:

                                        iM001Tema001.Attributes["style"] = "color: yellow";

                                        upMateria0001Tema0001.Update();
                                        break;

                                    case 2:

                                        iM001Tema002.Attributes["style"] = "color: yellow";

                                        upMateria0001Tema0002.Update();
                                        break;

                                    case 3:

                                        iM001Tema003.Attributes["style"] = "color: yellow";

                                        upMateria0001Tema0003.Update();
                                        break;

                                    case 4:

                                        iM001Tema004.Attributes["style"] = "color: yellow";

                                        upMateria0001Tema0004.Update();
                                        break;

                                    case 5:

                                        iM001Tema005.Attributes["style"] = "color: yellow";

                                        upMateria0001Tema0005.Update();
                                        break;

                                    case 6:

                                        iM001Tema006.Attributes["style"] = "color: yellow";

                                        upMateria0001Tema0006.Update();
                                        break;

                                    case 7:

                                        iM001Tema007.Attributes["style"] = "color: yellow";

                                        upMateria0001Tema0007.Update();
                                        break;

                                    case 8:

                                        iM001Tema008.Attributes["style"] = "color: yellow";

                                        upMateria0001Tema0008.Update();
                                        break;

                                    case 9:

                                        iM001Tema009.Attributes["style"] = "color: yellow";

                                        upMateria0001Tema0009.Update();
                                        break;

                                    case 10:

                                        iM001Tema010.Attributes["style"] = "color: yellow";

                                        upMateria0001Tema0010.Update();
                                        break;

                                    case 11:

                                        iM001Tema0011.Attributes["style"] = "color: yellow";

                                        upMateria0001Tema0011.Update();
                                        break;

                                    case 12:

                                        iM001Tema012.Attributes["style"] = "color: yellow";

                                        upMateria0001Tema0012.Update();
                                        break;
                                }
                            }
                            if (FiltroMateriaID == 2)
                            {
                                int MatTemaID = OrdenMateriaTemaID;

                                switch (MatTemaID)
                                {
                                    case 1:

                                        iMateria0002Tema0001.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0001.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema1/index.html";
                                        break;

                                    case 2:

                                        iMateria0002Tema0002.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0002.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema2/index.html";
                                        break;

                                    case 3:

                                        iMateria0002Tema0003.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0003.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema3/index.html";
                                        break;

                                    case 4:

                                        iMateria0002Tema0004.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0004.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema4/index.html";
                                        break;

                                    case 5:

                                        iMateria0002Tema0005.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0005.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema5/index.html";
                                        break;

                                    case 6:

                                        iMateria0002Tema0006.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0006.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema6/index.html";
                                        break;

                                    case 7:

                                        iMateria0002Tema0007.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0007.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema7/index.html";
                                        break;

                                    case 8:

                                        iMateria0002Tema0008.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0008.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema8/index.html";
                                        break;

                                    case 9:

                                        iMateria0002Tema0009.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0009.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema9/index.html";
                                        break;

                                    case 10:

                                        iMateria0002Tema0010.Attributes["style"] = "color: yellow";

                                        upMateria0002Tema0010.Update();

                                        iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema10/index.html";
                                        break;
                                }
                            }

                            lblPuntDiag.Text = intCal.ToString();

                            divDiagnostico.Visible = false;

                            divEbook.Visible = true;
                            divComentario.Visible = true;

                            FiltroPreguntaDiagnostico = 0;

                            upDiagnostico.Update();
                            upComentario.Update();
                            upTema.Update();

                            Mensaje("Diagnostico Terminado");
                        }
                    }
                }
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
            divResultado.Visible = false;
            using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
            {
                var iRespuesta = (from a in mMateria.catMateriaTemaSintesis
                                  where a.UsuarioID == usr_ID
                                  select a
                                   ).ToList();

                string strcomment1 = Request.Form["comment1"];
                var i_registro = new imDesarrolloEntities();
                usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                var dn_usr = new catMateriaTemaSintesis
                {
                    UsuarioID = usr_ID,
                    Sintesis = strcomment1,
                    MateriaTemaID = FiltroMateriaTemaID,
                    FechaRegistro = DateTime.Now
                };

                i_registro.catMateriaTemaSintesis.Add(dn_usr);

                i_registro.SaveChanges();

                divComentario.Visible = false;

                divPreguntas.Visible = true;

                dtPreguntasCuestionario = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 2);

                DataRow[] foundRows;
                foundRows = dtPreguntasCuestionario.Select("NuevoID = 1");

                FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                lblPregunta.Text = foundRows[0][1].ToString();

                radioR1.Checked = false;
                radioR2.Checked = false;
                radioR3.Checked = false;
                radioR4.Checked = false;

                var iRespuestaf = (from c in mMateria.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                   select c).ToList();

                int f1 = 1;
                foreach (var iResp in iRespuestaf)
                {
                    string strlbl = "lblRespuesta00" + f1;

                    if (strlbl == "lblRespuesta001")
                    {
                        lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                        lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                    }

                    if (strlbl == "lblRespuesta002")
                    {
                        lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                        lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                    }

                    if (strlbl == "lblRespuesta003")
                    {
                        lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                        lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                    }

                    if (strlbl == "lblRespuesta004")
                    {
                        lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                        lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                    }
                    f1 += 1;
                }
                upPreguntas.Update();
            }
        }

        protected void btnGuardaRespuesta_Click(object sender, EventArgs e)
        {
            if (radioR1.Checked == false & radioR2.Checked == false & radioR3.Checked == false & radioR4.Checked == false)
            {
                Mensaje("Favor de seleccionar una opción");
            }
            else
            {
                using (imDesarrolloEntities mTema = new imDesarrolloEntities())
                {
                    var iBitacora = (from a in mTema.catMateriaTemaPreguntaRespuestaBitacora
                                     where a.UsuarioID == usr_ID
                                     where a.TipoPreguntaID == 2
                                     select a
                                      ).ToList();
                    if (iBitacora.Count != dtPreguntasCuestionario.Rows.Count)
                    {
                        if (radioR1.Checked == true || radioR2.Checked == true || radioR3.Checked == true || radioR4.Checked == true)
                        {
                            int intRespuesta = 0;
                            if (radioR1.Checked)
                            {
                                intRespuesta = int.Parse(lblResp001.Text);
                            }
                            else if (radioR2.Checked)
                            {
                                intRespuesta = int.Parse(lblResp002.Text);
                            }
                            else if (radioR3.Checked)
                            {
                                intRespuesta = int.Parse(lblResp003.Text);
                            }
                            else if (radioR4.Checked)
                            {
                                intRespuesta = int.Parse(lblResp004.Text);
                            }

                            using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                            {
                                var iRespuestaf = (from a in mMateria.catMateriaTemaPreguntaRespuesta
                                                   where a.MateriaTemaPreguntaRespuestaID == intRespuesta
                                                   select a
                                                 ).FirstOrDefault();

                                bool vRespuesta = bool.Parse(iRespuestaf.Respuesta.ToString());

                                if (vRespuesta)
                                {
                                    var i_registro = new imDesarrolloEntities();
                                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                                    var dn_usr = new catMateriaTemaPreguntaRespuestaBitacora
                                    {
                                        TipoPreguntaID = 2,
                                        UsuarioID = usr_ID,
                                        MateriaTemaPreguntaRespuestaID = intRespuesta,
                                        MateriaTemaPreguntaID = FiltroPreguntaIDc,
                                        FechaRegistro = DateTime.Now
                                    };

                                    i_registro.catMateriaTemaPreguntaRespuestaBitacora.Add(dn_usr);

                                    i_registro.SaveChanges();
                                }
                                else
                                {
                                    usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                                    var i_registro = new imDesarrolloEntities();

                                    var dn_usr = new catMateriaTemaPreguntaRespuestaBitacora
                                    {
                                        TipoPreguntaID = 2,
                                        UsuarioID = usr_ID,
                                        MateriaTemaPreguntaRespuestaID = intRespuesta,
                                        MateriaTemaPreguntaID = FiltroPreguntaIDc,
                                        FechaRegistro = DateTime.Now
                                    };

                                    i_registro.catMateriaTemaPreguntaRespuestaBitacora.Add(dn_usr);

                                    i_registro.SaveChanges();
                                }
                            }
                        }

                        var iBitacoraR = (from a in mTema.catMateriaTemaPreguntaRespuestaBitacora
                                          where a.UsuarioID == usr_ID
                                          where a.TipoPreguntaID == 2
                                          select a
                              ).ToList();
                        string filtro;
                        FiltroPreguntaTest = iBitacoraR.Count;

                        FiltroPreguntaTest += 1;

                        try
                        {
                            filtro = "NuevoID = " + FiltroPreguntaTest.ToString();

                            DataRow[] foundRows;
                            foundRows = dtPreguntasCuestionario.Select(filtro);
                            divDiagnostico.Visible = true;
                            lblPregunta.Text = foundRows[0][1].ToString();
                            FiltroPreguntaIDc = int.Parse(foundRows[0][2].ToString());

                            var iRespuesta = (from c in mTema.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, FiltroPreguntaIDc)
                                              select c).ToList();

                            int f1 = 1;
                            foreach (var iResp in iRespuesta)
                            {
                                string strlbl = "lblRespuesta00" + f1;

                                if (strlbl == "lblRespuesta001")
                                {
                                    lblRespuesta001.Text = iResp.MateriaTemaPreguntaRespuesta;
                                    lblResp001.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                                }

                                if (strlbl == "lblRespuesta002")
                                {
                                    lblRespuesta002.Text = iResp.MateriaTemaPreguntaRespuesta;
                                    lblResp002.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                                }

                                if (strlbl == "lblRespuesta003")
                                {
                                    lblRespuesta003.Text = iResp.MateriaTemaPreguntaRespuesta;
                                    lblResp003.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                                }

                                if (strlbl == "lblRespuesta004")
                                {
                                    lblRespuesta004.Text = iResp.MateriaTemaPreguntaRespuesta;
                                    lblResp004.Text = iResp.MateriaTemaPreguntaRespuestaID.ToString();
                                }
                                f1 += 1;

                                if (iRespuesta.Count == 3)
                                {
                                    radioR4.Visible = false;
                                }
                            }

                            radioR1.Checked = false;
                            radioR2.Checked = false;
                            radioR3.Checked = false;
                            radioR4.Checked = false;

                            upPreguntas.Update();
                        }
                        catch (Exception)
                        {
                            usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                            using (imDesarrolloEntities mMateria = new imDesarrolloEntities())
                            {
                                var iMateria = (from a in mMateria.catMateriaTemaPreguntaRespuestaBitacora
                                                join b in mMateria.catMateriaTemaPreguntaRespuesta on a.MateriaTemaPreguntaRespuestaID equals b.MateriaTemaPreguntaRespuestaID
                                                join c in mMateria.catMateriaTemaPregunta on b.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                                                join d in mMateria.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                                                where a.TipoPreguntaID == 2
                                                where b.Respuesta == true
                                                where a.UsuarioID == usr_ID
                                                where d.MateriaTemaID == FiltroMateriaTemaID
                                                where d.MateriaID == FiltroMateriaID
                                                select a).ToList();

                                int intPunt = iMateria.Count;
                                int intCal = (intPunt * 10) / dtPreguntasCuestionario.Rows.Count;

                                if (FiltroMateriaID == 1)
                                {
                                    int MatTemaID = FiltroMateriaTemaID;

                                    switch (MatTemaID)
                                    {
                                        case 1:

                                            iM001Tema001.Attributes["style"] = "color: green";

                                            upMateria0001Tema0001.Update();
                                            break;

                                        case 2:

                                            iM001Tema002.Attributes["style"] = "color: green";

                                            upMateria0001Tema0002.Update();
                                            break;

                                        case 3:

                                            iM001Tema003.Attributes["style"] = "color: green";

                                            upMateria0001Tema0003.Update();
                                            break;

                                        case 4:

                                            iM001Tema004.Attributes["style"] = "color: green";

                                            upMateria0001Tema0004.Update();
                                            break;

                                        case 5:

                                            iM001Tema005.Attributes["style"] = "color: green";

                                            upMateria0001Tema0005.Update();
                                            break;

                                        case 6:

                                            iM001Tema006.Attributes["style"] = "color: green";

                                            upMateria0001Tema0006.Update();
                                            break;

                                        case 7:

                                            iM001Tema007.Attributes["style"] = "color: green";

                                            upMateria0001Tema0007.Update();
                                            break;

                                        case 8:

                                            iM001Tema008.Attributes["style"] = "color: green";

                                            upMateria0001Tema0008.Update();
                                            break;

                                        case 9:

                                            iM001Tema009.Attributes["style"] = "color: green";

                                            upMateria0001Tema0009.Update();
                                            break;

                                        case 10:

                                            iM001Tema010.Attributes["style"] = "color: green";

                                            upMateria0001Tema0010.Update();
                                            break;

                                        case 11:

                                            iM001Tema0011.Attributes["style"] = "color: green";

                                            upMateria0001Tema0011.Update();
                                            break;

                                        case 12:

                                            iM001Tema012.Attributes["style"] = "color: green";

                                            upMateria0001Tema0012.Update();
                                            break;
                                    }
                                }
                                if (FiltroMateriaID == 2)
                                {
                                    int MatTemaID = OrdenMateriaTemaID;

                                    switch (MatTemaID)
                                    {
                                        case 1:

                                            iMateria0002Tema0001.Attributes["style"] = "color: green";

                                            upMateria0002Tema0001.Update();
                                            break;

                                        case 2:

                                            iMateria0002Tema0002.Attributes["style"] = "color: green";

                                            upMateria0002Tema0002.Update();
                                            break;

                                        case 3:

                                            iMateria0002Tema0003.Attributes["style"] = "color: green";

                                            upMateria0002Tema0003.Update();
                                            break;

                                        case 4:

                                            iMateria0002Tema0004.Attributes["style"] = "color: green";

                                            upMateria0002Tema0004.Update();
                                            break;

                                        case 5:
                                            iMateria0002Tema0005.Attributes["style"] = "color: green";

                                            upMateria0002Tema0005.Update();
                                            break;

                                        case 6:

                                            iMateria0002Tema0006.Attributes["style"] = "color: green";

                                            upMateria0002Tema0006.Update();
                                            break;

                                        case 7:

                                            iMateria0002Tema0007.Attributes["style"] = "color: green";

                                            upMateria0002Tema0007.Update();
                                            break;

                                        case 8:

                                            iMateria0002Tema0008.Attributes["style"] = "color: green";

                                            upMateria0002Tema0008.Update();

                                            break;

                                        case 9:

                                            iMateria0002Tema0009.Attributes["style"] = "color: green";

                                            upMateria0002Tema0009.Update();

                                            break;

                                        case 10:

                                            iMateria0002Tema0010.Attributes["style"] = "color: green";
                                            iM002.Attributes["style"] = "color: green";
                                            upMateria0002Tema0010.Update();
                                            upMateria0002.Update();

                                            break;
                                    }
                                }

                                lblPuntuacion.Text = intCal.ToString();

                                divDiagnostico.Visible = false;

                                divPreguntas.Visible = false;
                                usr_ID = Guid.Parse(Request.Cookies["usr_cookie"].Value);
                                var iMateriaf = (from a in mMateria.catMateriaTemaPreguntaRespuestaBitacora
                                                 join b in mMateria.catMateriaTemaPreguntaRespuesta on a.MateriaTemaPreguntaRespuestaID equals b.MateriaTemaPreguntaRespuestaID
                                                 join c in mMateria.catMateriaTemaPregunta on b.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                                                 join d in mMateria.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                                                 where a.TipoPreguntaID == 2
                                                 where a.UsuarioID == usr_ID
                                                 where d.MateriaTemaID == FiltroMateriaTemaID
                                                 where d.MateriaID == FiltroMateriaID

                                                 select new
                                                 {
                                                     c.MateriaTemaPregunta,
                                                     b.MateriaTemaPreguntaRespuesta,
                                                     b.Respuesta,
                                                     b.Justificacion
                                                 }
                                               ).ToList();

                                if (iMateriaf.Count != 0)
                                {
                                    gvResultados.DataSource = iMateriaf;
                                    gvResultados.DataBind();
                                    gvResultados.Visible = true;
                                }

                                divResultado.Visible = true;
                                upResultado.Update();
                                upPreguntas.Update();

                                upTema.Update();
                            }

                            Mensaje("Cuestionario Terminado");
                        }
                    }
                }
            }
        }

        private void Mensaje(string contenido)
        {
            lblModalTitle.Text = "Intelimundo";
            lblModalBody.Text = contenido;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }

        protected void lkbSalir_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        #endregion Funciones

        #region ControlUsuarios

        protected void lkbUsuarios_Click(object sender, EventArgs e)
        {
            divDiagnostico.Visible = false;
            divEbook.Visible = false;
            divResultado.Visible = false;
            divComentario.Visible = false;
            divContainer.Visible = false;
            cardUsuario.Visible = true;
            upUsuario.Update();
            upContainer.Update();
        }

        private void SControlUsurio()
        {
            sBusquedaUsuario.Items.Clear();

            using (imDesarrolloEntities mConfiguracion = new imDesarrolloEntities())
            {
                var dConfiguracion = (from c in mConfiguracion.catBusquedaUsuario
                                      select c).ToList();

                sBusquedaUsuario.DataSource = dConfiguracion;
                sBusquedaUsuario.DataTextField = "BusquedaUsuario";
                sBusquedaUsuario.DataValueField = "BusquedaUsuarioID";
                sBusquedaUsuario.DataBind();

                sBusquedaUsuario.Items.Insert(0, new ListItem("*Buscar Por:", string.Empty));
            }
        }

        protected void lkbUsuarioAgregar_Click(object sender, EventArgs e)
        {
            sComposUsuario();
            limpiaRegistroUsuario();
            gvUsuarios.Visible = false;
            divDatosUsuario.Visible = true;
            divBuscaUsuario.Visible = false;
            upUsuario.Update();
        }

        protected void lkbUsuarioEdita_Click(object sender, EventArgs e)
        {
            divDatosUsuario.Visible = false;
            divBuscaUsuario.Visible = true;
            SControlUsurio();
            //FiltroUP = "pnl_usr";
        }

        private void limpiaRegistroUsuario()
        {
            sComposUsuario();
            iNombresUsuario.Value = string.Empty;
            iApaternoUsuario.Value = string.Empty;
            iAmaternoUsuario.Value = string.Empty;
            iNacimientoUsuario.Value = string.Empty;
            iUsuario.Value = string.Empty;
            iClave.Value = string.Empty;
            iEmailCorporativoUsuario.Value = string.Empty;
            iEmailPersonalUsuario.Value = string.Empty;
            iEmailCorporativoUsuario.Value = string.Empty;
        }

        private void sComposUsuario()
        {
            sTipoUsuario.Items.Clear();
            sPerfilUsuario.Items.Clear();
            sGeneroUsuario.Items.Clear();

            using (imDesarrolloEntities mSelect = new imDesarrolloEntities())
            {
                var dAreas = (from c in mSelect.catTipoUsuarios
                              select c).ToList();

                sTipoUsuario.DataSource = dAreas;
                sTipoUsuario.DataTextField = "TipoUsuario";
                sTipoUsuario.DataValueField = "TipoUsuarioID";
                sTipoUsuario.DataBind();

                sTipoUsuario.Items.Insert(0, new ListItem("Tipo de Usuario", string.Empty));

                var dPerfiles = (from c in mSelect.catPerfiles
                                 select c).ToList();

                sPerfilUsuario.DataSource = dPerfiles;
                sPerfilUsuario.DataTextField = "Perfil";
                sPerfilUsuario.DataValueField = "PerfilID";
                sPerfilUsuario.DataBind();

                sPerfilUsuario.Items.Insert(0, new ListItem("Perfil", string.Empty));

                var dGenero = (from c in mSelect.catGenero
                               select c).ToList();

                sGeneroUsuario.DataSource = dGenero;
                sGeneroUsuario.DataTextField = "Genero";
                sGeneroUsuario.DataValueField = "GeneroID";
                sGeneroUsuario.DataBind();

                sGeneroUsuario.Items.Insert(0, new ListItem("Género", string.Empty));
            }
        }

        #endregion ControlUsuarios
    }
}