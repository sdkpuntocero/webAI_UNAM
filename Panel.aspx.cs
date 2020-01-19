using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace webAI_UNAM
{
    public partial class Panel : System.Web.UI.Page
    {
        public static Guid empf_ID = Guid.Empty, usr_ID = Guid.Empty;
        public static int FiltroMateriaID = 0, OrdenMateriaTemaID = 0, FiltroMateriaTemaID = 0, FiltroMateriaTemaPreguntaID = 0, FiltroPreguntaDiagnostico = 0, FiltroPreguntaDiagnosticoID = 0, FiltroPreguntaTest = 0;
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

                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private void UsuarioFiltrado()
        {
        }

        #region Materia0001

        protected void lkbMateria0001Tema0001_Click(object sender, EventArgs e)
        {
        }

        #endregion Materia0001

        #region Materia0002

        protected void lkbMateria0002Tema0001_Click(object sender, EventArgs e)
        {
            divContainer.Visible = false;
            upContainer.Update();

            FiltroMateriaID = 2;
            OrdenMateriaTemaID = 1;

            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var fModelo = (from a in Modelo.catMateriaTema
                               where a.MateriaID == FiltroMateriaID
                               where a.MateriaOrdenID == OrdenMateriaTemaID
                               select a
                                   ).FirstOrDefault();

                lblTema.Text = fModelo.MateriaTema;
                FiltroMateriaTemaID = fModelo.MateriaTemaID;
            }

            play_video.Visible = true;
            play_video.Attributes["src"] = "Material/Universidad/Espanol/Tema1/test-video.mp4";

            if (EstatusTemas(FiltroMateriaID, OrdenMateriaTemaID))
            {
                
                divTema.Visible = true; divContainer.Visible = false; upTema.Visible = true;  upContainer.Visible = true; 
                lblPuntDiag.Text = "0";

                divComentario.Visible = false;
                comment1.Value = string.Empty;

                //lblPuntuacion.Text = "0";
                //cardPreguntas.Visible = false;
                //cardResultado.Visible = false;
                //upResultado.Update();

                //iframeTema.Attributes["src"] = "Material/Universidad/Espanol/Tema1/index.html";

                //ebbokTema.Visible = false;
                //btnDiagnostico.Visible = true;
            }
            else
            {
                divTema.Visible = false;
                divContainer.Visible = true;
                iMateria0002Tema0001.Attributes["style"] = "color: green";
                upMateria0002Tema0001.Update();
                upContainer.Update();
            }

            upTema.Update();
            upContainer.Update();
        }

        protected void lkbMateria0002Tema0002_Click(object sender, EventArgs e)
        {
        }

        protected void lkbMateria0002Tema0003_Click(object sender, EventArgs e)
        {
        }

        protected void lkbMateria0002Tema0004_Click(object sender, EventArgs e)
        {
        }

        protected void lkbMateria0002Tema0005_Click(object sender, EventArgs e)
        {
        }

        protected void lkbMateria0002Tema0006_Click(object sender, EventArgs e)
        {
        }

        protected void lkbMateria0002Tema0007_Click(object sender, EventArgs e)
        {
        }

        protected void lkbMateria0002Tema0008_Click(object sender, EventArgs e)
        {
        }

        protected void lkbMateria0002Tema0009_Click(object sender, EventArgs e)
        {
        }

        protected void lkbMateria0002Tema0010_Click(object sender, EventArgs e)
        {
        }

        #endregion Materia0002

        #region Funciones

        protected void btnDiagnostico_Click(object sender, EventArgs e)
        {
            int PreguntaID;

            btnDiagnostico.Visible = false;
            upGuardaDiagnostico.Update();

            dtPreguntasDiagnostico = GetTable(FiltroMateriaID, FiltroMateriaTemaID, 1);

            DataRow[] foundRows;
            foundRows = dtPreguntasDiagnostico.Select("NuevoID = 1");

            PreguntaID = int.Parse(foundRows[0][2].ToString());
            divDiagnostico.Visible = true;
            lblTemaDiagnostico.Text = foundRows[0][1].ToString();

            rbRespDiag001.Checked = false;
            rbRespDiag002.Checked = false;
            rbRespDiag003.Checked = false;
            rbRespDiag004.Checked = false;

            using (imDesarrolloEntities mTema = new imDesarrolloEntities())
            {
                var iRespuesta = (from c in mTema.RespuestasSP(FiltroMateriaID, FiltroMateriaTemaID, PreguntaID)
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
            FiltroPreguntaDiagnostico = 1;
            upDiagnostico.Update();
        }

        private bool EstatusTemas(int MateriaID, int MateriaTemaID)
        {
            using (imDesarrolloEntities Modelo = new imDesarrolloEntities())
            {
                var iModelo = (from a in Modelo.catMateriaTemaPreguntaRespuestaBitacora
                               join b in Modelo.catMateriaTemaPreguntaRespuesta on a.MateriaTemaPreguntaRespuestaID equals b.MateriaTemaPreguntaRespuestaID
                               join c in Modelo.catMateriaTemaPregunta on b.MateriaTemaPreguntaID equals c.MateriaTemaPreguntaID
                               join d in Modelo.catMateriaTema on c.MateriaTemaID equals d.MateriaTemaID
                               where d.MateriaID == MateriaID
                               where d.MateriaOrdenID == MateriaTemaID
                               where a.UsuarioID == usr_ID
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

        #endregion Funciones
    }
}