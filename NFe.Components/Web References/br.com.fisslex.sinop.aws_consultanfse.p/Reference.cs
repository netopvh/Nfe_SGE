﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace NFe.Components.br.com.fisslex.sinop.aws_consultanfse.p {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WS_ConsultaNfseSoapBinding", Namespace="FISS-LEX")]
    public partial class WS_ConsultaNfse : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ExecuteOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WS_ConsultaNfse() {
            this.Url = global::NFe.Components.Properties.Settings.Default.NFe_Components_br_com_fisslex_sinop_aws_consultanfse_p_WS_ConsultaNfse;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ExecuteCompletedEventHandler ExecuteCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("FISS-LEXaction/AWS_CONSULTANFSE.Execute", RequestElementName="WS_ConsultaNfse.Execute", RequestNamespace="FISS-LEX", ResponseElementName="WS_ConsultaNfse.ExecuteResponse", ResponseNamespace="FISS-LEX", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("Consultarnfseresposta")]
        public string Execute(ConsultarNfseEnvio Consultarnfseenvio, [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)] out tcMensagemRetorno[] Listamensagemretorno) {
            object[] results = this.Invoke("Execute", new object[] {
                        Consultarnfseenvio});
            Listamensagemretorno = ((tcMensagemRetorno[])(results[1]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ExecuteAsync(ConsultarNfseEnvio Consultarnfseenvio) {
            this.ExecuteAsync(Consultarnfseenvio, null);
        }
        
        /// <remarks/>
        public void ExecuteAsync(ConsultarNfseEnvio Consultarnfseenvio, object userState) {
            if ((this.ExecuteOperationCompleted == null)) {
                this.ExecuteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExecuteOperationCompleted);
            }
            this.InvokeAsync("Execute", new object[] {
                        Consultarnfseenvio}, this.ExecuteOperationCompleted, userState);
        }
        
        private void OnExecuteOperationCompleted(object arg) {
            if ((this.ExecuteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ExecuteCompleted(this, new ExecuteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="FISS-LEX")]
    public partial class ConsultarNfseEnvio {
        
        private tcIdentificacaoPrestador prestadorField;
        
        private int numeroNfseField;
        
        private ABRASFConsultarNfseEnvioPeriodoEmissao periodoEmissaoField;
        
        private tcIdentificacaoTomador tomadorField;
        
        private tcIdentificacaoIntermediarioServico intermediarioServicoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public tcIdentificacaoPrestador Prestador {
            get {
                return this.prestadorField;
            }
            set {
                this.prestadorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int NumeroNfse {
            get {
                return this.numeroNfseField;
            }
            set {
                this.numeroNfseField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ABRASFConsultarNfseEnvioPeriodoEmissao PeriodoEmissao {
            get {
                return this.periodoEmissaoField;
            }
            set {
                this.periodoEmissaoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public tcIdentificacaoTomador Tomador {
            get {
                return this.tomadorField;
            }
            set {
                this.tomadorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public tcIdentificacaoIntermediarioServico IntermediarioServico {
            get {
                return this.intermediarioServicoField;
            }
            set {
                this.intermediarioServicoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="FISS-LEX")]
    public partial class tcIdentificacaoPrestador {
        
        private string cnpjField;
        
        private string inscricaoMunicipalField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Cnpj {
            get {
                return this.cnpjField;
            }
            set {
                this.cnpjField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string InscricaoMunicipal {
            get {
                return this.inscricaoMunicipalField;
            }
            set {
                this.inscricaoMunicipalField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="FISS-LEX")]
    public partial class tcMensagemRetorno {
        
        private string codigoField;
        
        private string mensagemField;
        
        private string correcaoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Codigo {
            get {
                return this.codigoField;
            }
            set {
                this.codigoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Mensagem {
            get {
                return this.mensagemField;
            }
            set {
                this.mensagemField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Correcao {
            get {
                return this.correcaoField;
            }
            set {
                this.correcaoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="FISS-LEX")]
    public partial class tcIdentificacaoIntermediarioServico {
        
        private string razaoSocialField;
        
        private tcCpfCnpj cpfCnpjField;
        
        private string inscricaoMunicipalField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RazaoSocial {
            get {
                return this.razaoSocialField;
            }
            set {
                this.razaoSocialField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public tcCpfCnpj CpfCnpj {
            get {
                return this.cpfCnpjField;
            }
            set {
                this.cpfCnpjField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string InscricaoMunicipal {
            get {
                return this.inscricaoMunicipalField;
            }
            set {
                this.inscricaoMunicipalField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="FISS-LEX")]
    public partial class tcCpfCnpj {
        
        private string cpfField;
        
        private string cnpjField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Cpf {
            get {
                return this.cpfField;
            }
            set {
                this.cpfField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Cnpj {
            get {
                return this.cnpjField;
            }
            set {
                this.cnpjField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="FISS-LEX")]
    public partial class tcIdentificacaoTomador {
        
        private tcCpfCnpj cpfCnpjField;
        
        private string inscricaoMunicipalField;
        
        private string inscricaoEstadualField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public tcCpfCnpj CpfCnpj {
            get {
                return this.cpfCnpjField;
            }
            set {
                this.cpfCnpjField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string InscricaoMunicipal {
            get {
                return this.inscricaoMunicipalField;
            }
            set {
                this.inscricaoMunicipalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string InscricaoEstadual {
            get {
                return this.inscricaoEstadualField;
            }
            set {
                this.inscricaoEstadualField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="ABRASFConsultarNfseEnvio.PeriodoEmissao", Namespace="FISS-LEX")]
    public partial class ABRASFConsultarNfseEnvioPeriodoEmissao {
        
        private System.Nullable<System.DateTime> dataInicialField;
        
        private System.Nullable<System.DateTime> dataFinalField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<System.DateTime> DataInicial {
            get {
                return this.dataInicialField;
            }
            set {
                this.dataInicialField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<System.DateTime> DataFinal {
            get {
                return this.dataFinalField;
            }
            set {
                this.dataFinalField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void ExecuteCompletedEventHandler(object sender, ExecuteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExecuteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ExecuteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public tcMensagemRetorno[] Listamensagemretorno {
            get {
                this.RaiseExceptionIfNecessary();
                return ((tcMensagemRetorno[])(this.results[1]));
            }
        }
    }
}

#pragma warning restore 1591