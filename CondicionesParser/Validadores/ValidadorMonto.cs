using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesParser.Parser;
using CondicionesParser.Parametros;
using System.Text.RegularExpressions;

namespace CondicionesParser.Validadores
{
    public class ValidadorMonto : AbstractValidator
    {
        private string _Unidades = "|USD|$|R$|Euros|Won|Bolívares|Guaraníes|U$S|ADP|AED|AFA|ALL|AMD|ANG|AOK|ARA|ARS|ATS|AUD|AWG|AZM|BAD|BBD|BDT|BEF|BGL|BHD|BIF|BMD|BND|BOB|BRL|BRR|BSD|BWP|BYR|BZD|CAD|CDP|CHF|CLP|CNY|COP|CRC|CUP|CVE|CYP|CZK|DEM|DJF|DKK|DOP|DRP|DZD|ECS|ECU|EEK|EGP|ESP|ETB|EUR|FIM|FJD|FKP|FRF|GBP|GEK|GHC|GIP|GMD|GNF|GRD|GTQ|GWP|GYD|HKD|HNL|HRD|HTG|HUF|IDR|IEP|ILS|INR|IQD|IRR|ISK|ITL|JMD|JOD|JPY|KES|KHR|KIS|KMF|KPW|KRW|KWD|KYD|KZT|LAK|LBP|LKR|LRD|LSL|LTL|LUF|LVL|LYD|MAD|MDL|MGF|MNC|MNT|MOP|MRO|MTL|MUR|MVR|MWK|MXN|MXP|MYR|MZM|NGN|NIC|NIO|NIS|NLG|NOK|NPR|NZD|OMR|PAB|PEI|PEN|PES|PGK|PHP|PKR|PLN|PLZ|PTE|PYG|QAR|RMB|ROL|RUR|RWF|SAR|SBD|SCR|SDP|SEK|SGD|SHP|SIT|SKK|SLL|SOL|SOS|SRG|STD|SUR|SVC|SYP|SZL|THB|TJR|TMM|TND|TOP|TPE|TRL|TTD|TWD|TZS|UAK|UGS|USD|UYP|UYU|VEB|VND|VUV|WST|XAF|XCD|XOF|YER|ZAR|ZMK|ZRZ|ZWD|";

        protected override void ValidarTipoDato(string Dato, string Ubicacion)
        {
            ValidarFloat(Dato);
        }

        protected override string Unidades()
        {
            return _Unidades;
        }
    }
}
