using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace AuditDecreto
{
    public partial class Form1 : Form

    {

        private string connectionString = "Server=SQL8020.site4now.net;Database=db_a44c8c_proyemaestria;User Id=db_a44c8c_proyemaestria_admin;Password=Umg@1111proye!!;";

        public Form1()
        {
            InitializeComponent();
            dgvDecreto.CellClick += dgvDecreto_CellClick;
        }

        private void CargarDatos()

        {
            // Conexión a la base de datos

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Consulta para obtener los títulos y artículos
                string query = @"
                    SELECT d.Nombre AS DecretoNombre, t.TituloId, t.Nombre AS TituloNombre, a.ArticuloId, a.Numero AS ArticuloNumero, a.Texto AS ArticuloTexto, i.IncisoId, i.Letra, i.Texto AS IncisoTexto
                    FROM Decretos d
                    JOIN Titulos t ON d.DecretoId = t.DecretoId
                    LEFT JOIN Articulos a ON t.TituloId = a.TituloId
                    LEFT JOIN Incisos i ON a.ArticuloId = i.ArticuloId
                    ORDER BY d.Nombre, t.Numero, a.Numero, i.Letra";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    string currentDecreto = string.Empty;
                    string currentTitulo = string.Empty;
                    string currentArticulo = string.Empty;

                    while (reader.Read())
                    {
                        // Obtener los datos
                        string decretoNombre = reader["DecretoNombre"].ToString();
                        string tituloNombre = reader["TituloNombre"].ToString();
                        int articuloNumero = reader.IsDBNull(reader.GetOrdinal("ArticuloNumero")) ? -1 : reader.GetInt32(reader.GetOrdinal("ArticuloNumero"));
                        string articuloTexto = reader["ArticuloTexto"].ToString();
                        string incisoLetra = reader["Letra"].ToString();
                        string incisoTexto = reader["IncisoTexto"].ToString();

                        // Mostrar título si es diferente al actual
                        if (currentDecreto != decretoNombre)
                        {
                            currentDecreto = decretoNombre;
                            Label lblDecreto = new Label { Text = decretoNombre, Font = new Font("Arial", 12, FontStyle.Bold), AutoSize = true };
                            //FlPanel.Controls.Add(lblDecreto);
                            dgvDecreto.Columns.Add("Column", "Descripción");

                            DataGridViewCheckBoxColumn checkBoxColumnCumple = new DataGridViewCheckBoxColumn
                            {
                                HeaderText = "Cumple",
                                Name = "CumpleColumn",
                                Width = 50,
                                TrueValue = true,
                                FalseValue = false
                            };
                            dgvDecreto.Columns.Add(checkBoxColumnCumple);
                            DataGridViewCheckBoxColumn checkBoxNoColumnCumple = new DataGridViewCheckBoxColumn
                            {
                                HeaderText = "No Cumple",
                                Name = "NoCumpleColumn",
                                Width = 50,
                                TrueValue = true,
                                FalseValue = false
                            };
                            dgvDecreto.Columns.Add(checkBoxNoColumnCumple);
                            DataGridViewCheckBoxColumn checkBoxParcial = new DataGridViewCheckBoxColumn
                            {
                                HeaderText = "Cumple Parcial",
                                Name = "CumplePColumn",
                                Width = 50,
                                TrueValue = true,
                                FalseValue = false
                            };
                            dgvDecreto.Columns.Add(checkBoxParcial);
                            DataGridViewButtonColumn checkBoxAdjunto = new DataGridViewButtonColumn
                            {
                                HeaderText = "Adjunto",
                                Name = "AdjuntoColumn",
                                Text = "Adjuntar Evidencia",
                                UseColumnTextForButtonValue = true,
                                Width = 50
                            };
                            dgvDecreto.Columns.Add("Column","Observaciones");
                            dgvDecreto.Columns.Add(checkBoxAdjunto);
                            dgvDecreto.Columns.Add("RutaArchivo", "Ruta del Archivo");

                            dgvDecreto.Rows.Add(reader["DecretoNombre"].ToString());

                        }
                        for (int i = 0; i < dgvDecreto.Rows.Count; i++)
                        {
                            if (i == 0 || i == 1) // Deshabilitar filas con índice 0 y 1
                            {
                                // Establecer las celdas como de solo lectura
                                dgvDecreto.Rows[i].ReadOnly = true;

                                // Cambiar el estilo visual de la fila para indicar que está deshabilitada
                                dgvDecreto.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                                dgvDecreto.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                                dgvDecreto.Rows[i].DefaultCellStyle.SelectionBackColor = Color.LightGray;
                                dgvDecreto.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Black;
                            }
                        }

                        // Mostrar título si es diferente al actual
                        if (currentTitulo != tituloNombre)
                        {
                            currentTitulo = tituloNombre;
                            Label lblTitulo = new Label { Text = tituloNombre, Font = new Font("Arial", 12, FontStyle.Bold), AutoSize = true };
                            dgvDecreto.Rows.Add(reader["TituloNombre"].ToString());
                        }

                        // Mostrar artículo si es diferente al actual
                        if (articuloNumero != -1 && currentArticulo != articuloTexto)
                        {
                            currentArticulo = articuloTexto;
                            Label lblArticulo = new Label { Text = $"Artículo {articuloNumero}: {articuloTexto}", Font = new Font("Arial", 10, FontStyle.Regular), AutoSize = true };
                            dgvDecreto.Rows.Add(reader["ArticuloTexto"].ToString());

                        }

                        // Mostrar inciso si existe
                        if (!string.IsNullOrEmpty(incisoTexto))
                        {
                            Label lblInciso = new Label { Text = $"Inciso {incisoLetra}: {incisoTexto}", Font = new Font("Arial", 9, FontStyle.Italic), AutoSize = true };
                            dgvDecreto.Rows.Add(reader["IncisoTexto"].ToString());
                        }
                    }
                    reader.Close();
                }
            }
        }

        // Manejar el evento CellClick para el DataGridView
        private void dgvDecreto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si el clic fue en la columna de botones "AdjuntoColumn"
            if (e.RowIndex >= 0 && dgvDecreto.Columns[e.ColumnIndex].Name == "AdjuntoColumn")
            {
                // Crear y configurar el diálogo para seleccionar archivos
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Seleccione un archivo",
                    Filter = "Todos los archivos (*.*)|*.*" // Puedes ajustar el filtro a tus necesidades
                };

                // Mostrar el diálogo y verificar si el usuario seleccionó un archivo
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    // Aquí puedes agregar la lógica para manejar el archivo adjunto
                    // Por ejemplo, mostrar un mensaje de confirmación
                    MessageBox.Show($"Archivo '{selectedFilePath}' adjuntado correctamente.", "Archivo Adjuntado");

                    // Opcional: Puedes guardar la ruta del archivo o hacer algo con él
                     dgvDecreto.Rows[e.RowIndex].Cells["RutaArchivo"].Value = selectedFilePath;
                }
            }
        }


        private void BtnCargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        //private void BtnCargar_Click(object sender, EventArgs e)
        //{

        //}

        private void BtnMonitorear_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            int totalFilasEvaluadas = 0;
            int cumpleMarcados = 0;
            int noCumpleMarcados = 0;
            int cumpleParcialmenteMarcados = 0;

            // Recorrer las filas del DataGridView
            foreach (DataGridViewRow row in dgvDecreto.Rows)
            {
                // Solo contar filas que no sean de solo lectura (ya que esas están deshabilitadas)
                if (!row.ReadOnly)
                {
                    totalFilasEvaluadas++;

                    // Verificar si los CheckBox están marcados
                    bool cumple = Convert.ToBoolean(row.Cells["CumpleColumn"].Value);
                    bool noCumple = Convert.ToBoolean(row.Cells["NoCumpleColumn"].Value);
                    bool cumpleParcial = Convert.ToBoolean(row.Cells["CumplePColumn"].Value);

                    if (cumple) cumpleMarcados++;
                    if (noCumple) noCumpleMarcados++;
                    if (cumpleParcial) cumpleParcialmenteMarcados++;
                }
            }

            // Calcular el porcentaje
            double porcentajeCumple = (totalFilasEvaluadas > 0) ? (cumpleMarcados / (double)totalFilasEvaluadas) * 100 : 0;
            double porcentajeNoCumple = (totalFilasEvaluadas > 0) ? (noCumpleMarcados / (double)totalFilasEvaluadas) * 100 : 0;
            double porcentajeCumpleParcial = (totalFilasEvaluadas > 0) ? (cumpleParcialmenteMarcados / (double)totalFilasEvaluadas) * 100 : 0;

            // Mostrar los resultados en un mensaje
            MessageBox.Show($"Resultados de Monitoreo:\n" +
                            $"Cumple: {cumpleMarcados} de {totalFilasEvaluadas} ({porcentajeCumple:0.00}%)\n" +
                            $"No Cumple: {noCumpleMarcados} de {totalFilasEvaluadas} ({porcentajeNoCumple:0.00}%)\n" +
                            $"Cumple Parcialmente: {cumpleParcialmenteMarcados} de {totalFilasEvaluadas} ({porcentajeCumpleParcial:0.00}%)",
                            "Monitoreo de Cumplimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LblCumple.Text = $"Cumple: {cumpleMarcados} de {totalFilasEvaluadas} ({porcentajeCumple:0.00}%)";
            LblNocumple.Text = $"No Cumple: {noCumpleMarcados} de {totalFilasEvaluadas} ({porcentajeNoCumple:0.00}%)";
            LblParcial.Text = $"Cumple Parcialmente: {cumpleParcialmenteMarcados} de {totalFilasEvaluadas} ({porcentajeCumpleParcial:0.00}%)";
            ActualizarGrafico(cumpleMarcados, noCumpleMarcados, cumpleParcialmenteMarcados);
        }

        private void Evaluar()
        {
            int totalFilasEvaluadas = 0;
            int cumpleMarcados = 0;
            int noCumpleMarcados = 0;
            int cumpleParcialmenteMarcados = 0;

            // Recorrer las filas del DataGridView
            foreach (DataGridViewRow row in dgvDecreto.Rows)
            {
                // Solo contar filas que no sean de solo lectura (ya que esas están deshabilitadas)
                if (!row.ReadOnly)
                {
                    totalFilasEvaluadas++;

                    // Verificar si los CheckBox están marcados
                    bool cumple = Convert.ToBoolean(row.Cells["CumpleColumn"].Value);
                    bool noCumple = Convert.ToBoolean(row.Cells["NoCumpleColumn"].Value);
                    bool cumpleParcial = Convert.ToBoolean(row.Cells["CumplePColumn"].Value);

                    if (cumple) cumpleMarcados++;
                    if (noCumple) noCumpleMarcados++;
                    if (cumpleParcial) cumpleParcialmenteMarcados++;
                }
            }

            // Calcular el porcentaje
            double porcentajeCumple = (totalFilasEvaluadas > 0) ? (cumpleMarcados / (double)totalFilasEvaluadas) * 100 : 0;
            double porcentajeNoCumple = (totalFilasEvaluadas > 0) ? (noCumpleMarcados / (double)totalFilasEvaluadas) * 100 : 0;
            double porcentajeCumpleParcial = (totalFilasEvaluadas > 0) ? (cumpleParcialmenteMarcados / (double)totalFilasEvaluadas) * 100 : 0;

            // Mostrar los resultados en un mensaje
            MessageBox.Show($"Resultados de Monitoreo:\n" +
                            $"Cumple: {cumpleMarcados} de {totalFilasEvaluadas} ({porcentajeCumple:0.00}%)\n" +
                            $"No Cumple: {noCumpleMarcados} de {totalFilasEvaluadas} ({porcentajeNoCumple:0.00}%)\n" +
                            $"Cumple Parcialmente: {cumpleParcialmenteMarcados} de {totalFilasEvaluadas} ({porcentajeCumpleParcial:0.00}%)",
                            "Monitoreo de Cumplimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LblCumple.Text = "Cumple: {cumpleMarcados} de {totalFilasEvaluadas} ({porcentajeCumple:0.00}%)";
            LblNocumple.Text = "No Cumple: {noCumpleMarcados} de {totalFilasEvaluadas} ({porcentajeNoCumple:0.00}%)";
            LblParcial.Text = "Cumple Parcialmente: {cumpleParcialmenteMarcados} de {totalFilasEvaluadas} ({porcentajeCumpleParcial:0.00}%)";
            ActualizarGrafico(cumpleMarcados, noCumpleMarcados, cumpleParcialmenteMarcados);

        }

        private void ActualizarGrafico(int cumple, int noCumple, int cumpleParcial)
        {
            // Limpiar series existentes
            chart1.Series.Clear();

            // Crear una nueva serie
            Series series = new Series("Cumplimiento");
            series.ChartType = SeriesChartType.Pie; // Puedes cambiar a Column, Bar, etc.

            // Agregar puntos de datos
            series.Points.AddXY("Cumple", cumple);
            series.Points.AddXY("No Cumple", noCumple);
            series.Points.AddXY("Cumple Parcialmente", cumpleParcial);

            // Añadir la serie al gráfico
            chart1.Series.Add(series);

            // Personalizar la apariencia del gráfico (opcional)
            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Black";
            chart1.Titles.Clear();
            chart1.Titles.Add("Distribución de Cumplimiento");

        }

        private void GenerarReporteNoCumple()
        {
            // Crear una lista para almacenar las filas que no cumplen
            List<string> reporte = new List<string>();
            reporte.Add("Informe de Evaluación de Cumplimiento de Normas Legales\n");
            reporte.Add($"Entidad evaluada: Banco Ejemplo");
            reporte.Add($"Fecha de evaluación: Agosto 2024");
            reporte.Add($"Evaluadores: Juan Perez");
            reporte.Add($"Ley evaluada: Ley de Panama\n");
            reporte.Add("Objetivo de la evaluación:");
            reporte.Add($"El objetivo de esta evaluación es determinar el grado de cumplimiento de Banco ejemplo con las normas establecidas en Ley de Panama. " +
                        "La evaluación se ha llevado a cabo de acuerdo con los parámetros establecidos por [Organismo o entidad reguladora, si aplica], " +
                        "considerando los artículos, títulos e incisos relevantes para la actividad de la entidad.\n");

            reporte.Add("Metodología de evaluación:");
            reporte.Add($"Se realizó una revisión exhaustiva de los procedimientos, prácticas y documentación de Banco ejemplo en relación con los requisitos legales especificados en  Ley de Panama. " +
                        "Cada artículo e inciso relevante fue analizado para determinar si se cumple, no se cumple o se cumple parcialmente. " +
                        "Además, se han tomado en cuenta las observaciones pertinentes para cada sección evaluada.\n");

            int totalFilasEvaluadas = 0;
            int noCumpleMarcados = 0;
            int parcialMarcados = 0;


            // Recorrer las filas del DataGridView
            foreach (DataGridViewRow row in dgvDecreto.Rows)
            {
                // Solo contar filas que no sean de solo lectura (ya que esas están deshabilitadas)
                if (!row.ReadOnly)
                {
                    // Contar el total de filas evaluadas
                    totalFilasEvaluadas++;

                    // Verificar si el CheckBox de "No Cumple" está marcado
                    bool noCumple = Convert.ToBoolean(row.Cells["NoCumpleColumn"].Value);
                    bool parcial = Convert.ToBoolean(row.Cells["CumplePColumn"].Value);

                    if (noCumple)
                    {
                        // Obtener los datos de la fila
                        string descripcion = row.Cells["Column"].Value?.ToString() ?? "Sin descripción";
                        string observaciones = row.Cells[4].Value?.ToString() ?? "Sin observaciones";
                        string adjunto = row.Cells[6].Value?.ToString() ?? "Sin adjunto";
                        // string observaciones = row.Cells["Observaciones"].Value?.ToString() ?? "Sin observaciones";


                        // Construir la línea del reporte con la descripción del artículo que no cumple
                        string lineaReporte = $"\nDescripción: {descripcion}\n" +
                                              $"Observaciones: {observaciones}\n" +
                                              $"Adjunto: {adjunto}\n" +
                                              "---------------------------";

                        // Agregar la línea al reporte
                        reporte.Add(lineaReporte);

                        // Contar los artículos que no cumplen
                        noCumpleMarcados++;
                    }

                    if (parcial)
                    {
                        // Obtener los datos de la fila
                        string descripcion = row.Cells["Column"].Value?.ToString() ?? "Sin descripción";
                        string observaciones = row.Cells[4].Value?.ToString() ?? "Sin observaciones";
                        string adjunto = row.Cells[6].Value?.ToString() ?? "Sin adjunto";
                        // string observaciones = row.Cells["Observaciones"].Value?.ToString() ?? "Sin observaciones";


                        // Construir la línea del reporte con la descripción del artículo que no cumple
                        string lineaReporte = $"\nDescripción: {descripcion}\n" +
                                              $"Observaciones: {observaciones}\n" +
                                              $"Adjunto: {adjunto}\n" +
                                              "---------------------------";

                        // Agregar la línea al reporte
                        reporte.Add(lineaReporte);

                        // Contar los artículos que no cumplen
                        noCumpleMarcados++;
                    }
                }
            }

            // Calcular el porcentaje de artículos que no cumplen
            double porcentajeNoCumple = (totalFilasEvaluadas > 0) ? (noCumpleMarcados / (double)totalFilasEvaluadas) * 100 : 0;

            // Agregar información resumen al reporte
            reporte.Add("\n==========================================");
            reporte.Add("  Resumen de Resultados");
            reporte.Add("==========================================");
            reporte.Add($"Total de artículos evaluados: {totalFilasEvaluadas}");
            reporte.Add($"Total de artículos que no cumplen: {noCumpleMarcados}");
            reporte.Add($"Porcentaje de incumplimiento: {porcentajeNoCumple:0.00}%");

            // Especificar la ruta del archivo de reporte
            string rutaArchivo = "ReporteNoCumple.txt";

            // Guardar el reporte en el archivo
            File.WriteAllLines(rutaArchivo, reporte);

            // Informar al usuario que el reporte ha sido generado
            MessageBox.Show($"Reporte de artículos que no cumplen generado exitosamente en: {rutaArchivo}",
                            "Reporte Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            // Definir la ruta del archivo de reporte
            string rutaReporte = "reporte_no_cumple.txt";

            // Crear un StreamWriter para escribir el archivo
            using (StreamWriter writer = new StreamWriter(rutaReporte))
            {
                GenerarReporteNoCumple();
            }

            //MessageBox.Show("Reporte generado exitosamente en 'reporte_no_cumple.txt'.", "Reporte Generado");
        }

        private void evaluadorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PnlFondo.Visible = false;
            PnlInicio.Visible = false;
            evaluadorToolStripMenuItem.Visible = false;
            supervisorToolStripMenuItem.Visible = false;
            evaluadoToolStripMenuItem.Visible = false;
            dgvDecreto.Visible = false;
            chart1.Visible = false;
            txtPreview.Visible = false;
            BtnCargar.Visible = false;
            BtnMonitorear.Visible = false;
            BtnReporte.Visible = false;
            BtnPreview.Visible = false;
        }




        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pblogo.Visible = false;
            PnlFondo.Visible = true;
            PnlInicio.Visible = true;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            
            string correo = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT u.UsuarioID, u.Nombre, r.NombreRol FROM Usuarios u " +
                               "INNER JOIN Roles r ON u.RoleID = r.RoleID " +
                               "WHERE u.Correo = @correo AND u.Contrasena = @contrasena";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@correo", correo);
                    command.Parameters.AddWithValue("@contrasena", contrasena);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Obtén el rol del usuario
                            string rol = reader["NombreRol"].ToString();

                            // Mostrar mensaje de bienvenida
                            MessageBox.Show("Bienvenido, " + reader["Nombre"].ToString() + "!", "Inicio de Sesión Exitoso");

                            // Verifica el rol y muestra el botón si es administrador
                            if (rol == "Admin")
                            {

                                evaluadorToolStripMenuItem.Visible = true;
                                supervisorToolStripMenuItem.Visible = true;
                                evaluadoToolStripMenuItem.Visible = true;
                                PnlFondo.Visible = false;
                                PnlInicio.Visible = false;
                            }
                            else if (rol == "Supervisor")
                            {
                                supervisorToolStripMenuItem.Visible = true;
                                PnlFondo.Visible = true;
                                PnlInicio.Visible = true;
                                PnlFondo.Visible = false;
                                PnlInicio.Visible = false;
                            }
                            else if (rol == "Evaluador")
                            {
                                evaluadorToolStripMenuItem.Visible = true;
                                PnlFondo.Visible = false;
                                PnlInicio.Visible = false;
                            }
                            else if (rol == "Evaluado")
                            {
                                evaluadoToolStripMenuItem.Visible = true;
                                PnlFondo.Visible = false;
                                PnlInicio.Visible = false;
                            }
                            else
                            {
                                evaluadorToolStripMenuItem.Visible = false;
                            }
                        }
                        else
                        {
                            // Si las credenciales son incorrectas
                            MessageBox.Show("Correo o contraseña incorrectos.", "Error");
                            txtUsuario.Text = "";
                            txtContrasena.Text = "";
                        }
                    }
                }
            }
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            evaluadorToolStripMenuItem.Visible = false;
            supervisorToolStripMenuItem.Visible = false;
            evaluadoToolStripMenuItem.Visible = false;
            PnlFondo.Visible = true;
            PnlInicio.Visible = true;
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            dgvDecreto.Visible = false;
            chart1.Visible = false;
            BtnMonitorear.Visible = false;
            BtnPreview.Visible = false;
            BtnReporte.Visible  = false;
            pblogo.Visible =false;
            LblCumple.Visible = false;
            LblNocumple.Visible = false;
            LblParcial.Visible = false;
        }

        private void cargarDecretoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvDecreto.Visible = true;
            CargarDatos();
            BtnMonitorear.Visible = true;
            BtnReporte.Visible = true;
        }

        private void evaluaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            Evaluar();
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
        }

        private void resultadoEvaluaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtPreview.Visible = true;
            // Especificar la ruta del archivo de reporte
            string rutaArchivo = @"C:\Users\hilver.guzman\source\repos\AuditDecreto\AuditDecreto\bin\Debug\net8.0-windows\ReporteNoCumple.txt";

            // Verificar si el archivo existe antes de intentar leerlo
            if (File.Exists(rutaArchivo))
            {
                // Leer el contenido del archivo
                string contenido = File.ReadAllText(rutaArchivo);

                // Mostrar el contenido en el TextBox de vista previa
                txtPreview.Text = contenido;
            }
            else
            {
                // Mostrar un mensaje si el archivo no existe
                MessageBox.Show("El archivo de reporte no se encontró. Por favor, genera el reporte antes de intentar visualizarlo.",
                                "Archivo No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
