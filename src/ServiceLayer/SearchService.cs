using AbstractLayer;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ServiceLayer
{
    /// <summary>
    /// Formulario de búsqueda genérico.
    /// </summary>
    public partial class BusquedaBase : Form
    {
        /// <summary>
        /// <see cref="BusquedaBase"/>
        /// </summary>
        public BusquedaBase()
        {
            InitializeComponent();
        }

        // Componentes de la interfaz de usuario.

        /// <summary> TextBox para ingresar el criterio de búsqueda. </summary>
        protected TextBox CriterioTextbox;

        /// <summary> Botón para iniciar la búsqueda. </summary>
        protected Button BuscarButton;

        /// <summary> ListBox para mostrar los resultados de la búsqueda. </summary>
        protected ListBox ResultadosListbox;

        // Eventos de los componentes.

        /// <summary> Evento del botón de búsqueda. </summary>
        public event EventHandler ButtonEventHandler;

        /// <summary> Evento de doble clic en el ListBox. </summary>
        public event EventHandler ListboxEventHandler;

        //......................................................................

        private void InitializeComponent()
        {
            CriterioTextbox = new TextBox();
            BuscarButton = new Button();
            ResultadosListbox = new ListBox();
            SuspendLayout();
            // 
            // CriterioTextbox
            // 
            CriterioTextbox.Location = new Point(20, 23);
            CriterioTextbox.Name = "CriterioTextbox";
            CriterioTextbox.Size = new Size(200, 30);
            CriterioTextbox.TabIndex = 0;
            // 
            // BuscarButton
            // 
            BuscarButton.Location = new Point(230, 20);
            BuscarButton.Name = "BuscarButton";
            BuscarButton.Size = new Size(80, 30);
            BuscarButton.TabIndex = 1;
            BuscarButton.Text = "Buscar";
            BuscarButton.UseVisualStyleBackColor = true;
            BuscarButton.Click += BuscarButton_Click;
            // 
            // ResultadosListbox
            // 
            ResultadosListbox.FormattingEnabled = true;
            ResultadosListbox.Location = new Point(20, 65);
            ResultadosListbox.Name = "ResultadosListbox";
            ResultadosListbox.Size = new Size(290, 360);
            ResultadosListbox.TabIndex = 2;
            ResultadosListbox.DoubleClick += ResultadosListbox_DoubleClick;
            // 
            // SearchBase
            // 
            ClientSize = new Size(330, 435);
            Font = new Font("Calibri", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Controls.Add(ResultadosListbox);
            Controls.Add(BuscarButton);
            Controls.Add(CriterioTextbox);
            ResumeLayout(false);
            PerformLayout();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            ButtonEventHandler?.Invoke(this, e);
        }

        private void ResultadosListbox_DoubleClick(object sender, EventArgs e)
        {
            ListboxEventHandler?.Invoke(this, e);
        }
    }

    /// <summary>
    /// Servicio de búsqueda genérico.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class SearchService<T> : BusquedaBase
    {
        /// <summary>
        /// <see cref="SearchService{T}"/>
        /// </summary>
        /// <param name="buscable"></param>
        public SearchService(IBuscable<T> buscable)
        {
            // Algo de estética
            StartPosition = FormStartPosition.CenterScreen;
            Icon = new Icon("Resources/Search.ico");
            Text = $"Búsqueda de {typeof(T).Name}";

            // Lógica de búsqueda
            _buscable = buscable;
            ButtonEventHandler += OnButton_Clicked;
            ListboxEventHandler += OnListbox_DoubleClicked;

            // Configurar manejadores de eventos de teclado
            KeyPreview = true;
            KeyDown += SearchForm_KeyDown;
            CriterioTextbox.KeyDown += CriterioTextbox_KeyDown;
            ResultadosListbox.KeyDown += ResultadosListbox_KeyDown;
        }

        private readonly IBuscable<T> _buscable;

        /// <summary> Elemento seleccionado en el ListBox. </summary>
        public T SelectedItem { get; private set; }

        //......................................................................

        private void OnButton_Clicked(object sender, EventArgs e)
        {
            var criterio = CriterioTextbox.Text;
            var resultados = _buscable.Buscar(criterio);
            ResultadosListbox.DataSource = resultados.ToList();
        }

        private void OnListbox_DoubleClicked(object sender, EventArgs e)
        {
            if (ResultadosListbox.SelectedItem != null)
            {
                SelectedItem = (T)ResultadosListbox.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }

        // Manejar el evento KeyDown del formulario
        private void SearchForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        // Manejar el evento KeyDown del TextBox
        private void CriterioTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) BuscarButton.PerformClick();
        }

        // Manejar el evento KeyDown del ListBox
        private void ResultadosListbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) OnListbox_DoubleClicked(sender, e);
        }
    }
}
