using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Backend.Dominio;
using Backend.Homes;
using System.Text.RegularExpressions;

namespace CondicionesMigracion.ACNetServicio
{
    public class ServicioMigracionDocumentos
    {
        #region Singleton

        private static ServicioMigracionDocumentos _Instancia;

        private ServicioMigracionDocumentos()
        {
        }

        public static ServicioMigracionDocumentos Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new ServicioMigracionDocumentos();
            }
            return _Instancia;
        }

        #endregion


        private void CondicionesGenerales(string Path, TipoDocumento TipoDocumento, Idioma Idioma)
        {
            string[] FileNames = Directory.GetFiles(Path, "*.*");

            for (int I = 0; I < FileNames.Length; I++)
            {
                FileStream stream = new FileStream(FileNames[I],
                    FileMode.Open, FileAccess.Read);
                BinaryReader Reader = new BinaryReader(stream);

                Documento Documento = new Documento();
                Documento.TipoDocumento = TipoDocumento;
                string[] Partes = Regex.Split(FileNames[I].Replace("\\", "/"), "/");
                Documento.Nombre = Partes[Partes.Length - 1].Trim();
                Documento.DocumentoContenido = Reader.ReadBytes((int)stream.Length);
                Documento.DocumentoDimension = (int)stream.Length;
                Documento.DocumentoTipoContenido = "application/pdf";
                Documento.CodigoValidacion = Guid.NewGuid();
                Documento.Idioma = Idioma;

                Documento.Persistir();
            }
        }
/*        private void CondicionesGeneralesEspanol(string Path, TipoDocumento TipoDocumento)
        {
            string[] FileNames = Directory.GetFiles(Path, "*.*");

            for (int I = 0; I < FileNames.Length; I++)
            {
                FileStream stream = new FileStream(FileNames[I],
                    FileMode.Open, FileAccess.Read);
                BinaryReader Reader = new BinaryReader(stream);

                Documento Documento = new Documento();
                Documento.TipoDocumento = TipoDocumento;
                string[] Partes = Regex.Split(FileNames[I].Replace("\\", "/"), "/");
                Documento.Nombre = Partes[Partes.Length -1].Trim();
                Documento.DocumentoContenido = Reader.ReadBytes((int)stream.Length);
                Documento.DocumentoDimension = (int)stream.Length;
                Documento.DocumentoTipoContenido = "pdf";
                Documento.CodigoValidacion = Guid.NewGuid();
                Documento.Idioma = IdiomaHome.Espanol();

                Documento.Persistir();
            }
        }*/

        private void CondicionesGeneralesEspanol()
        {
            CondicionesGenerales(
                "C:/Documentos-CCGG-ES", 
                TipoDocumentoHome.Obtener(TipoDocumento.CONDICIONES_GENERALES),
                IdiomaHome.Espanol());
        }

        private void CondicionesGeneralesIngles()
        {
            CondicionesGenerales(
                "C:\\Documentos-CCGG-EN",
                TipoDocumentoHome.Obtener(TipoDocumento.CONDICIONES_GENERALES),
                IdiomaHome.Ingles());
        }

        private void CondicionesGeneralesPortugues()
        {
            CondicionesGenerales(
                "C:\\Documentos-CCGG-PT",
                TipoDocumentoHome.Obtener(TipoDocumento.CONDICIONES_GENERALES),
                IdiomaHome.Portugues());
        }

        public void Migrar()
        {
            CondicionesGeneralesEspanol();
            CondicionesGeneralesIngles();
            CondicionesGeneralesPortugues();
        }
    }
}
