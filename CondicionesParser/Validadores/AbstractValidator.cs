using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesParser.Parametros;
using CondicionesParser.Parser;
using System.Text.RegularExpressions;

namespace CondicionesParser.Validadores
{
    public abstract class AbstractValidator : IValidadorParametro
    {
        #region Validacion Partes Condicion

        private void ValidarParametro(string Parametro, string Ubicacion)
        {
            if (!ContenedorParametros.Instancia(Ubicacion).Todos().Contains(Parametro))
            {
                throw new Excepciones.ParserException("Parametro ingresado no definido.");
            }
        }

        private void ValidarOperador(string Operador, string Ubicacion)
        {
            if (!ContenedorOperadores.Instancia().Todos().Contains(Operador.ToUpper().Trim().Replace("-", "")))
            {
                throw new Excepciones.ParserException("Operador ingresado no definido.");
            }
        }

        private void ValidarFormatoGeneral(string[] Partes)
        {
            if (Partes == null || Partes.Length < 2)
            {
                throw new Excepciones.ParserException("Formato General Invalido.");
            }
        }

        private void ValidarFormatoCondicion(string[] Partes)
        {
            if (Partes == null || Partes.Length < 2)
            {
                throw new Excepciones.ParserException("Formato Condicion Invalido.");
            }
        }

        protected void ValidarUnidad(string Parametro, string Unidad, string Ubicacion)
        {            
            if (Unidades() != null && 
                Unidades().Length > 0 && !Unidades().ToUpper().Contains(Unidad))
            {
                throw new Excepciones.ParserException("Unidad " + Unidad + " invalida");
            }
        }

        #endregion

        #region Validacion tipo dato

        protected void ValidarEntero(string Dato)
        {
            try
            {
                Convert.ToInt32(Dato);
            }
            catch (Exception)
            {
                throw new Excepciones.ParserException("Debe ser numero entero: " + Dato);
            }
        }

        protected void ValidarFloat(string Dato)
        {
            try
            {
                Convert.ToDouble(Dato);
            }
            catch (Exception)
            {
                throw new Excepciones.ParserException("Debe ser numerico: " + Dato);
            }
        }

        protected void ValidarBoolean(string Dato)
        {
            try
            {
                Convert.ToBoolean(Dato);
            }
            catch (Exception)
            {
                throw new Excepciones.ParserException("Debe ser boolean (true/false): " + Dato);
            }
        }

        #endregion

        #region Validaciones a implementar

        protected abstract void ValidarTipoDato(string Dato, string Ubicacion);

        protected abstract string Unidades();

        #endregion

        #region IValidadorParametro Members

        public void ValidarFormato(string Condicion, string Ubicacion)
        {
            string[] Partes = Regex.Split(Condicion.Trim(), 
                ContenedorOperadores.SEPARADOR_TIPO_PARAMETRO);

            ValidarFormatoGeneral(Partes);

            string Parametro = Partes[0];

            ValidarParametro(Parametro, Ubicacion);

            Partes = Regex.Split(Partes[1].Trim(), ContenedorOperadores.SEPARADOR_PARAMETRO);

            ValidarFormatoCondicion(Partes);

            ValidarOperador(Partes[0].Trim(), Ubicacion);

            ValidarTipoDato(Partes[1].Trim(), Ubicacion);

            if (Partes.Length > 2)
            {
                ValidarUnidad(Parametro, Partes[2].Trim(), Ubicacion);
            }
        }

        #endregion
    }
}
