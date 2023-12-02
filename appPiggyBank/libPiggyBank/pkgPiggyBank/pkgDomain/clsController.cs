using System;
using System.Collections.Generic;
using pkgServices.pkgCollections;
using pkgServices;
using System.Data.Common;

namespace pkgPiggyBank.pkgDomain
{
    /// <summary>
    /// Clase que act�a como controlador central para la gesti�n de monedas, alcanc�as y transacciones.
    /// </summary>
    public class clsController
   {
        #region Attributes
        /// <summary>
        /// Instancia �nica del controlador (patr�n Singleton).
        /// </summary>
        private static clsController attInstance;

        /// <summary>
        /// Lista de monedas gestionadas por el controlador.
        /// </summary>
        private List<clsCurrency> attCurrencies;

        /// <summary>
        /// Instancia de la alcanc�a gestionada por el controlador.
        /// </summary>
        private clsPiggyBank attPiggy;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor privado para asegurar que solo hay una instancia del controlador (patr�n Singleton).
        /// </summary>
        private clsController() { }
        #endregion
        #region Getters
        /// <summary>
        /// Obtiene la instancia �nica del controlador (patr�n Singleton).
        /// </summary>
        /// <returns>La instancia �nica del controlador.</returns>
        public static clsController getInstance()
        {
            if (attInstance == null) { 
                attInstance = new clsController();
            }
            return attInstance;
        }

        #endregion
        #region Cruds
        /// <summary>
        /// Registra una nueva moneda con sus valores de monedas y billetes.
        /// </summary>
        /// <param name="prmOID">Identificador �nico de la moneda.</param>
        /// <param name="prmName">Nombre de la moneda.</param>
        /// <param name="prmTRM">Tasa de cambio de la moneda.</param>
        /// <param name="prmCoinsValues">Lista de valores de monedas disponibles.</param>
        /// <param name="prmBillsValues">Lista de valores de billetes disponibles.</param>
        /// <returns>Devuelve true si el registro fue exitoso; de lo contrario, false.</returns>
        public bool toRegisterCurrency(string prmOID, string prmName, double prmTRM, List<double> prmCoinsValues, List<double> prmBillsValues)
        {
            return clsBrokerCrud.toRegisterEntity(new clsCurrency(prmOID, prmName, prmTRM, prmCoinsValues, prmBillsValues), attCurrencies);
        }

        /// <summary>
        /// Registra una nueva alcanc�a con sus l�mites y valores disponibles.
        /// </summary>
        /// <param name="prmOIDCurrency">Identificador �nico de la moneda asociada a la alcanc�a.</param>
        /// <param name="prmCoinsMaxCap">L�mite m�ximo de monedas en la alcanc�a.</param>
        /// <param name="prmBillsMaxCap">L�mite m�ximo de billetes en la alcanc�a.</param>
        /// <param name="prmCoinsValues">Lista de valores de monedas disponibles en la alcanc�a.</param>
        /// <param name="prmBillsValues">Lista de valores de billetes disponibles en la alcanc�a.</param>
        /// <returns>Devuelve true si el registro fue exitoso; de lo contrario, false.</returns>
        public bool toRegisterPiggyBank(string prmOIDCurrency, int prmCoinsMaxCap, int prmBillsMaxCap, List<double> prmCoinsValues, List<double> prmBillsValues)
        {
            if(attPiggy!=null) return false;
            clsCurrency varObj = clsCollections.getItemWith(prmOIDCurrency, attCurrencies);
            if (varObj == null) return false;
            attPiggy=new clsPiggyBank(prmCoinsMaxCap, prmBillsMaxCap, prmCoinsValues, prmBillsValues, varObj);
            varObj.setPiggyBank(attPiggy);
            return true;
        }

        /// <summary>
        /// Registra una nueva moneda en la alcanc�a.
        /// </summary>
        /// <param name="prmOIDCurrency">Identificador �nico de la moneda en la alcanc�a.</param>
        /// <param name="prmOID">Identificador �nico de la moneda a registrar.</param>
        /// <param name="prmValue">Valor de la moneda.</param>
        /// <param name="prmYear">A�o en que se cre� la moneda.</param>
        /// <returns>Devuelve true si el registro fue exitoso; de lo contrario, false.</returns>
        public bool toRegisterCoin(string prmOIDCurrency, string prmOID, double prmValue, int prmYear)
        {
            try
            {
                return clsCollections.getItemWith(prmOIDCurrency, attCurrencies).toRegisterCoin(prmOID, prmValue, prmYear); 
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Registra un nuevo billete en la alcanc�a.
        /// </summary>
        /// <param name="prmOIDCurrency">Identificador �nico de la moneda en la alcanc�a.</param>
        /// <param name="prmOID">Identificador �nico del billete a registrar.</param>
        /// <param name="prmValue">Valor del billete.</param>
        /// <param name="prmDay">D�a en que se cre� el billete.</param>
        /// <param name="prmMonth">Mes en que se cre� el billete.</param>
        /// <param name="prmYear">A�o en que se cre� el billete.</param>
        /// <returns>Devuelve true si el registro fue exitoso; de lo contrario, false.</returns>
        public bool toRegisterBill(string prmOIDCurrency, string prmOID, double prmValue, int prmDay, int prmMonth, int prmYear)
        {
            try
            {
                return clsCollections.getItemWith(prmOIDCurrency, attCurrencies).toRegisterBill(prmOID, prmValue, prmDay, prmMonth, prmYear);
            }
            catch (Exception e) {
                return false;
            }
        }

        /// <summary>
        /// Actualiza los valores de una moneda en la alcanc�a.
        /// </summary>
        /// <param name="prmOID">Identificador �nico de la moneda a actualizar.</param>
        /// <param name="prmName">Nuevo nombre de la moneda.</param>
        /// <param name="prmTRM">Nueva tasa de cambio de la moneda.</param>
        /// <param name="prmCoinsValues">Nuevos valores de monedas disponibles.</param>
        /// <param name="prmBillsValues">Nuevos valores de billetes disponibles.</param>
        /// <returns>Devuelve true si la actualizaci�n fue exitosa; de lo contrario, false.</returns>
        public bool toUptadeCurrency(string prmOID, string prmName, double prmTRM, List<double> prmCoinsValues, List<double> prmBillsValues)
        {
            clsCurrency varObj = clsCollections.getItemWith(prmOID, attCurrencies);
            if(varObj==null)return false;   
            return varObj.modify(prmName, prmTRM, prmCoinsValues, prmBillsValues);       
        }

        /// <summary>
        /// Actualiza los valores y l�mites de la alcanc�a asociada a una moneda.
        /// </summary>
        /// <param name="prmOIDCurrency">Identificador �nico de la moneda asociada a la alcanc�a.</param>
        /// <param name="prmCoinsMaxCap">Nuevo l�mite m�ximo de monedas en la alcanc�a.</param>
        /// <param name="prmBillsMaxCap">Nuevo l�mite m�ximo de billetes en la alcanc�a.</param>
        /// <param name="prmCoinsValues">Nuevos valores de monedas disponibles en la alcanc�a.</param>
        /// <param name="prmBillsValues">Nuevos valores de billetes disponibles en la alcanc�a.</param>
        /// <returns>Devuelve true si la actualizaci�n fue exitosa; de lo contrario, false.</returns>
        public bool toUpdatePiggyBank(string prmOIDCurrency, int prmCoinsMaxCap, int prmBillsMaxCap, List<double> prmCoinsValues, List<double> prmBillsValues)
        {
            if (attPiggy == null) return false;
            clsCurrency varObj = clsCollections.getItemWith(prmOIDCurrency, attCurrencies);
            if (varObj == null) return false;
            return attPiggy.modify(varObj, prmCoinsMaxCap, prmBillsMaxCap, prmCoinsValues, prmBillsValues);
        }

        /// <summary>
        /// Actualiza los valores de una moneda en la alcanc�a.
        /// </summary>
        /// <param name="prmOIDCurrency">Identificador �nico de la moneda en la alcanc�a.</param>
        /// <param name="prmOID">Identificador �nico de la moneda a actualizar.</param>
        /// <param name="prmValue">Nuevo valor de la moneda.</param>
        /// <param name="prmYear">Nuevo a�o de la moneda.</param>
        /// <returns>Devuelve true si la actualizaci�n fue exitosa; de lo contrario, false.</returns>
        public bool toUpdateCoin(string prmOIDCurrency, string prmOID, double prmValue, int prmYear)
        {
            clsCurrency varObj= clsCollections.getItemWith(prmOIDCurrency, attCurrencies);
            if (varObj == null) return false;
            return varObj.toUpdateCoin(prmOID, prmValue, prmYear);
        }

        /// <summary>
        /// Actualiza los valores de un billete en la alcanc�a.
        /// </summary>
        /// <param name="prmOIDCurrency">Identificador �nico de la moneda en la alcanc�a.</param>
        /// <param name="prmOID">Identificador �nico del billete a actualizar.</param>
        /// <param name="prmValue">Nuevo valor del billete.</param>
        /// <param name="prmDay">Nuevo d�a de creaci�n del billete.</param>
        /// <param name="prmMonth">Nuevo mes de creaci�n del billete.</param>
        /// <param name="prmYear">Nuevo a�o de creaci�n del billete.</param>
        /// <returns>Devuelve true si la actualizaci�n fue exitosa; de lo contrario, false.</returns>
        public bool toUpdateBill(string prmOIDCurrency, string prmOID, double prmValue, int prmDay, int prmMonth, int prmYear)
        {
            clsCurrency varObj = clsCollections.getItemWith(prmOIDCurrency, attCurrencies);
            if (varObj == null) return false;
            return varObj.toUpdateBill(prmOID, prmValue, prmYear);
        }

        /// <summary>
        /// Elimina una moneda de la lista de monedas gestionadas por el controlador.
        /// </summary>
        /// <param name="prmOID">Identificador �nico de la moneda a eliminar.</param>
        /// <returns>Devuelve true si la eliminaci�n fue exitosa; de lo contrario, false.</returns>
        public bool toDeleteCurrency(string prmOID)
        {
            clsCurrency varObj = clsCollections.getItemWith(prmOID, attCurrencies);
            if (varObj == null) return false;
            if (!varObj.die()) return false;
            return attCurrencies.Remove(varObj);

        }

        /// <summary>
        /// Elimina la alcanc�a actual si existe.
        /// </summary>
        /// <returns>Devuelve true si la eliminaci�n de la alcanc�a fue exitosa; de lo contrario, false.</returns>
        public bool toDeletePiggyBank()
        {
            if(attPiggy==null) return false;
            return attPiggy.die();
        }

        /// <summary>
        /// Elimina una moneda espec�fica de una moneda dada.
        /// </summary>
        /// <param name="prmOIDCurrency">Identificador �nico de la moneda asociada a la moneda a eliminar.</param>
        /// <param name="prmOID">Identificador �nico de la moneda a eliminar.</param>
        /// <returns>Devuelve true si la eliminaci�n fue exitosa; de lo contrario, false.</returns>
        public bool toDeleteCoin(string prmOIDCurrency, string prmOID)
        {
            clsCurrency varObj = clsCollections.getItemWith(prmOIDCurrency, attCurrencies);
            if (varObj == null) return false;
            return varObj.toDeleteCoin(prmOID);
        }

        /// <summary>
        /// Elimina un billete espec�fico de una moneda dada.
        /// </summary>
        /// <param name="prmOIDCurrency">Identificador �nico de la moneda asociada al billete a eliminar.</param>
        /// <param name="prmOID">Identificador �nico del billete a eliminar.</param>
        /// <returns>Devuelve true si la eliminaci�n fue exitosa; de lo contrario, false.</returns>
        public bool toDeleteBill(string prmOIDCurrency, string prmOID)
        {
            clsCurrency varObj = clsCollections.getItemWith(prmOIDCurrency, attCurrencies);
            if (varObj == null) return false;
            return varObj.toDeleteBill(prmOID);
        }


        #endregion
        #region Transactions
        /// <summary>
        /// Realiza un ingreso de monedas a la alcanc�a.
        /// </summary>
        /// <param name="prmValues">Lista de valores de las monedas a ingresar.</param>
        /// <returns>Devuelve true si el ingreso fue exitoso; de lo contrario, false.</returns>
        public bool coinsIncome(List<double> prmValues)
        {
            if (attPiggy == null) return false;
            clsCurrency varObj = attPiggy.getCurrency();
            if(varObj== null) return false;
            if (!varObj.areValidValuesAsCoins(prmValues)) return false;
            List<clsCoin> varCoins = varObj.retrieveAsOutsideCoins(prmValues);
            if(varCoins == null) return false;
            if (varCoins.Count!=prmValues.Count) return false;  
            return attPiggy.coinsIncome(varCoins);
        }

        /// <summary>
        /// Realiza una retirada de monedas de la alcanc�a.
        /// </summary>
        /// <param name="prmValues">Lista de valores de las monedas a retirar.</param>
        /// <returns>Devuelve true si la retirada fue exitosa; de lo contrario, false.</returns>
        public bool coinsWithdrawal(List<double> prmValues)
        {
            if (attPiggy == null) return false;
            clsCurrency varObj = attPiggy.getCurrency();
            if (varObj == null) return false;
            List<clsCoin> varCoins = varObj.retrieveAsInsideCoins(prmValues);
            if(varCoins == null) return false;
            return attPiggy.coinsWithdrawal(varCoins);
        }

        /// <summary>
        /// Realiza un ingreso de billetes a la alcanc�a.
        /// </summary>
        /// <param name="prmValues">Lista de valores de los billetes a ingresar.</param>
        /// <returns>Devuelve true si el ingreso fue exitoso; de lo contrario, false.</returns>
        public bool billsIncome(List<double> prmValues)
        {
            if(attPiggy == null) return false;
            clsCurrency varObj = attPiggy.getCurrency();
            if (varObj == null) return false;
            if (!varObj.areValidValuesAsBills(prmValues)) return false;
            List<clsBill> varBills = varObj.retrieveAsOutsideBills(prmValues);
            if (varBills == null) return false;
            return attPiggy.billsIncome(varBills);
        }

        /// <summary>
        /// Realiza una retirada de billetes de la alcanc�a.
        /// </summary>
        /// <param name="prmValues">Lista de valores de los billetes a retirar.</param>
        /// <returns>Devuelve true si la retirada fue exitosa; de lo contrario, false.</returns>
        public bool billsWithdrawal(List<double> prmValues)
        {
            if (attPiggy == null) return false;
            clsCurrency varObj = attPiggy.getCurrency();
            if (varObj == null) return false;
            List<clsBill> varBills = varObj.retrieveAsInsideBills(prmValues);
            if (varBills == null) return false;
            return attPiggy.billsWithdrawal(varBills);
        } 
        #endregion
    }
}