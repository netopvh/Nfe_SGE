﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace NFe.Components
{
    public class TipoArquivoXML
    {
        public int nRetornoTipoArq { get; private set; }
        public string cRetornoTipoArq { get; private set; }
        /// <summary>
        /// Tag que deve ser assinada no XML, se o conteúdo estiver em branco é por que o XML não deve ser assinado
        /// </summary>
        public string TagAssinatura { get; private set; }
        /// <summary>
        /// Tag que tem o atributo ID no XML
        /// </summary>
        public string TagAtributoId { get; private set; }
        /// <summary>
        /// Tag que deve ser assinada no XML, se o conteúdo estiver em branco é por que o XML não deve ser assinado
        /// </summary>
        public string TagLoteAssinatura { get; private set; }
        /// <summary>
        /// Tag que tem o atributo ID no XML
        /// </summary>
        public string TagLoteAtributoId { get; private set; }
        public string cArquivoSchema { get; private set; }
        public string TargetNameSpace { get; private set; }

        public TipoArquivoXML(string rotaArqXML, int UFCod)
        {
            DefinirTipoArq(rotaArqXML, UFCod);
        }

        private void DefinirTipoArq(string fullPathXML, int UFCod)
        {
            nRetornoTipoArq = 0;
            cRetornoTipoArq = string.Empty;
            cArquivoSchema = string.Empty;
            TagAssinatura = string.Empty;
            TagAtributoId = string.Empty;
            TagLoteAssinatura = string.Empty;
            TagLoteAtributoId = string.Empty;
            TargetNameSpace = string.Empty;

            string versaoXML = string.Empty;
            string padraoNFSe = string.Empty;

            try
            {
                if (UFCod.ToString().Length == 7)
                {
                    switch (UFCod)
                    {
                        case 4314050: //Parobé
                            padraoNFSe = Functions.PadraoNFSe(UFCod).ToString() + "-4314050-";
                            break;

                        case 4125506: //São José dos Pinhais-PR (GINFES)
                            padraoNFSe = Functions.PadraoNFSe(UFCod).ToString() + "-4125506-";
                            break;

                        default:
                            padraoNFSe = Functions.PadraoNFSe(UFCod).ToString() + "-";
                            break;
                    }
                }

                if (File.Exists(fullPathXML))
                {
                    if (fullPathXML.EndsWith(".txt"))
                    {
                        this.nRetornoTipoArq = SchemaXML.MaxID + 104;
                        this.cRetornoTipoArq = "Arquivo '" + fullPathXML + " não pode ser um arquivo texto para validação";
                        return;
                    }

                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(fullPathXML);
                        string nome = doc.DocumentElement.Name;
                        string versao = string.Empty;
                        if (((XmlElement)(XmlNode)doc.GetElementsByTagName(doc.DocumentElement.Name)[0]).Attributes[NFe.Components.TpcnResources.versao.ToString()] != null)
                            versao = ((XmlElement)(XmlNode)doc.GetElementsByTagName(doc.DocumentElement.Name)[0]).Attributes[NFe.Components.TpcnResources.versao.ToString()].Value;
                        else if (((XmlElement)(XmlNode)doc.GetElementsByTagName(doc.DocumentElement.FirstChild.Name)[0]).Attributes[NFe.Components.TpcnResources.versao.ToString()] != null)
                            versao = ((XmlElement)(XmlNode)doc.GetElementsByTagName(doc.DocumentElement.FirstChild.Name)[0]).Attributes[NFe.Components.TpcnResources.versao.ToString()].Value;

                        if (versao.Equals("3.10") && string.IsNullOrEmpty(padraoNFSe))
                            versaoXML = "-" + versao;

                        InfSchema schema = null;
                        string chave = "";
                        try
                        {
                            if (string.IsNullOrEmpty(padraoNFSe))
                            {
                                if (nome.Equals("envEvento") || nome.Equals("eventoCTe"))
                                {
                                    XmlElement cl = (XmlElement)doc.GetElementsByTagName(NFe.Components.TpcnResources.tpEvento.ToString())[0];
                                    if (cl != null)
                                    {
                                        string evento = cl.InnerText;
                                        switch (evento)
                                        {
                                            case "110110":  //XML de Evento da CCe
                                            case "110111":  //XML de Envio de evento de cancelamento
                                            case "110113":  //XML de Envio do evento de contingencia EPEC, CTe
                                            case "110160":  //XML de Envio do evento de Registro Multimodal, CTe
                                            case "110140":  //EPEC
                                                nome = nome + evento;
                                                break;

                                            case "210200":  //XML Evento de manifestação do destinatário
                                            case "210210":  //XML Evento de manifestação do destinatário
                                            case "210220":  //XML Evento de manifestação do destinatário
                                            case "210240":  //XML Evento de manifestação do destinatário
                                                nome = "envConfRecebto";
                                                break;
                                        }
                                    }
                                }
                                else if (nome.Equals("eventoMDFe"))
                                {
                                    XmlElement cl = (XmlElement)doc.GetElementsByTagName(NFe.Components.TpcnResources.tpEvento.ToString())[0];
                                    if (cl != null)
                                    {
                                        nome = "eventoMDFe" + cl.InnerText;
                                    }
                                }
                            }

                            if (string.IsNullOrEmpty(padraoNFSe))
                                chave = TipoAplicativo.Nfe.ToString().ToUpper() + /*versaoXML + "-" + padraoNFSe +*/ "-" + nome;
                            else
                                chave = TipoAplicativo.Nfse.ToString().ToUpper() + versaoXML + "-" + padraoNFSe + nome;

                            schema = SchemaXML.InfSchemas[chave];
                        }
                        catch
                        {
                            throw new Exception(string.Format("Não foi possível identificar o tipo do XML para ser validado, ou seja, o sistema não sabe se é um XML de {0}, consulta, etc. ", string.IsNullOrEmpty(padraoNFSe) ? "NF-e/NFC-e/CT-e/MDF-e" : "NFS-e") +
                                "Por favor verifique se não existe algum erro de estrutura do XML que impede sua identificação. (Chave: " + chave + ")");
                        }

                        nRetornoTipoArq = schema.ID;
                        cRetornoTipoArq = schema.Descricao;
                        TagAssinatura = schema.TagAssinatura;
                        TagAtributoId = schema.TagAtributoId;
                        TagLoteAssinatura = schema.TagLoteAssinatura;
                        TagLoteAtributoId = schema.TagLoteAtributoId;
                        TargetNameSpace = schema.TargetNameSpace;

                        if (!string.IsNullOrEmpty(schema.ArquivoXSD))
                        {
                            if (string.IsNullOrEmpty(padraoNFSe))
                                cArquivoSchema = Path.Combine(Propriedade.PastaExecutavel, "NFe\\schemas\\" + string.Format(schema.ArquivoXSD, versao));
                            else
                                cArquivoSchema = Path.Combine(Propriedade.PastaExecutavel, "NFse\\schemas\\" + schema.ArquivoXSD);
                        }
                    }
                    catch (Exception ex)
                    {
                        this.nRetornoTipoArq = SchemaXML.MaxID + 102;
                        this.cRetornoTipoArq = ex.Message;
                    }
                }
                else
                {
                    this.nRetornoTipoArq = SchemaXML.MaxID + 100;
                    this.cRetornoTipoArq = "Arquivo XML não foi encontrado";
                }
            }
            catch (Exception ex)
            {
                this.nRetornoTipoArq = SchemaXML.MaxID + 103;
                this.cRetornoTipoArq = ex.Message;
            }

            if (this.nRetornoTipoArq == 0)
            {
                this.nRetornoTipoArq = SchemaXML.MaxID + 101;
                this.cRetornoTipoArq = "Não foi possível identificar o arquivo XML";
            }
        }
    }
}
