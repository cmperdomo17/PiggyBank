using pkgServices;
using pkgServices.pkgCollections;

namespace pkgPiggyBank.pkgDomain
{
    /// <summary>
    /// Representa una alcanc�a que puede contener monedas y billetes.
    /// </summary>
    public class clsPiggyBank : clsEntity, IComparable<clsPiggyBank> 
   {
        #region Attributes
        #region Owns
        /// <summary>
        /// Capacidad m�xima de monedas que puede contener la alcanc�a.
        /// </summary>
        private int attCoinsMaxCapacity;

        /// <summary>
        /// Valores de monedas aceptados por la alcanc�a.
        /// </summary>
        private List<double> attCoinsAcceptedValues;

        /// <summary>
        /// Valores de billetes aceptados por la alcanc�a.
        /// </summary>
        private List<double> attBillsAcceptedValues;

        /// <summary>
        /// Capacidad m�xima de billetes que puede contener la alcanc�a.
        /// </summary>
        private int attBillsMaxCapacity;

        /// <summary>
        /// Moneda de la alcanc�a.
        /// </summary>
        private clsCurrency attCurrency;
        #endregion
        #region Derivables
        /// <summary>
        /// Saldo total de la alcanc�a.
        /// </summary>
        private double attTotalBalance;

        /// <summary>
        /// Saldo de monedas de la alcanc�a.
        /// </summary>
        private double attCoinsBalance;

        /// <summary>
        /// Saldo de billetes de la alcanc�a.
        /// </summary>
        private double attBillsBalance;

        /// <summary>
        /// Cantidad de monedas en la alcanc�a.
        /// </summary>
        private int attCoinsCount;

        /// <summary>
        /// Cantidad de billetes en la alcanc�a.
        /// </summary>
        private int attBillsCount;

        /// <summary>
        /// Saldo de monedas por valor en la alcanc�a.
        /// </summary>
        private List<double> attCoinsBalanceByValue;

        /// <summary>
        /// Saldo de billetes por valor en la alcanc�a.
        /// </summary>
        private List<double> attBillsBalanceByValue;

        /// <summary>
        /// Cantidad de monedas por valor en la alcanc�a.
        /// </summary>
        private List<int> attCoinsCountByValue;

        /// <summary>
        /// Cantidad de billetes por valor en la alcanc�a.
        /// </summary>
        private List<int> attBillsCountByValue;
        #endregion
        #region Associatives
        /// <summary>
        /// Lista de monedas en la alcanc�a.
        /// </summary>
        private List<clsCoin> attCoins;

        /// <summary>
        /// Lista de billetes en la alcanc�a.
        /// </summary>
        private List<clsBill> attBills;
        #endregion
        #endregion
        #region Operations
        #region Constructors
        /// <summary>
        /// Constructor que inicializa una instancia de la clase clsPiggyBank con valores iniciales.
        /// </summary>
        /// <param name="prmCoinsMaxCap">Capacidad m�xima de monedas en la alcanc�a.</param>
        /// <param name="prmBillsMaxCap">Capacidad m�xima de billetes en la alcanc�a.</param>
        /// <param name="prmCoinsValues">Valores de monedas aceptados por la alcanc�a.</param>
        /// <param name="prmBillsValues">Valores de billetes aceptados por la alcanc�a.</param>
        /// <param name="prmCurrency">Moneda de la alcanc�a.</param>
        public clsPiggyBank(int prmCoinsMaxCap, int prmBillsMaxCap, List<double> prmCoinsValues, List<double> prmBillsValues, clsCurrency prmCurrency)
            :base(default)
        {
            attCoinsMaxCapacity = prmCoinsMaxCap;
            attBillsMaxCapacity = prmBillsMaxCap;   
            attCoinsAcceptedValues= prmCoinsValues;
            attBillsAcceptedValues= prmBillsValues;
            attCurrency = prmCurrency;
        }

        /// <summary>
        /// Constructor predeterminado de la clase clsPiggyBank.
        /// </summary>
        public clsPiggyBank() { }
        #endregion
        #region Getters
        /// <summary>
        /// Obtiene la capacidad m�xima de monedas en la alcanc�a.
        /// </summary>
        /// <returns>La capacidad m�xima de monedas en la alcanc�a.</returns>
        public int getCoinsMaxCapacity() => attCoinsMaxCapacity;

        /// <summary>
        /// Obtiene los valores de monedas aceptados por la alcanc�a.
        /// </summary>
        /// <returns>Los valores de monedas aceptados por la alcanc�a.</returns>
        public List<double> getCoinsAcceptedValues() => attCoinsAcceptedValues;

        /// <summary>
        /// Obtiene el saldo de monedas en la alcanc�a.
        /// </summary>
        /// <returns>El saldo de monedas en la alcanc�a.</returns>
        public double getCoinsBalance() => attCoinsBalance;

        /// <summary>
        /// Obtiene la cantidad de monedas en la alcanc�a.
        /// </summary>
        /// <returns>La cantidad de monedas en la alcanc�a.</returns>
        public int getCoinsCount()=> attCoinsCount;

        /// <summary>
        /// Obtiene el saldo de monedas por valor en la alcanc�a.
        /// </summary>
        /// <returns>El saldo de monedas por valor en la alcanc�a.</returns>
        public List<double> getCoinsBalanceByValue() => attCoinsBalanceByValue;

        /// <summary>
        /// Obtiene la cantidad de monedas por valor en la alcanc�a.
        /// </summary>
        /// <returns>La cantidad de monedas por valor en la alcanc�a.</returns>
        public List<int> getCoinsCountByValue() => attCoinsCountByValue;

        /// <summary>
        /// Obtiene la capacidad m�xima de billetes en la alcanc�a.
        /// </summary>
        /// <returns>La capacidad m�xima de billetes en la alcanc�a.</returns>
        public int getBillsMaxCapacity() => attBillsMaxCapacity;

        /// <summary>
        /// Obtiene los valores de billetes aceptados por la alcanc�a.
        /// </summary>
        /// <returns>Los valores de billetes aceptados por la alcanc�a.</returns>
        public List<double> getBillsAcceptedValues() => attBillsAcceptedValues;

        /// <summary>
        /// Obtiene el saldo de billetes en la alcanc�a.
        /// </summary>
        /// <returns>El saldo de billetes en la alcanc�a.</returns>
        public double getBillsBalance() => attBillsBalance;

        /// <summary>
        /// Obtiene el saldo de billetes por valor en la alcanc�a.
        /// </summary>
        /// <returns>El saldo de billetes por valor en la alcanc�a.</returns>
        public List<double> getBillsBalanceByValue()=> attBillsBalanceByValue;

        /// <summary>
        /// Obtiene la cantidad de billetes en la alcanc�a.
        /// </summary>
        /// <returns>La cantidad de billetes en la alcanc�a.</returns>
        public int getBillsCount()=> attBillsCount;

        /// <summary>
        /// Obtiene la cantidad de billetes por valor en la alcanc�a.
        /// </summary>
        /// <returns>La cantidad de billetes por valor en la alcanc�a.</returns>
        public List<int> getBillsCountByValue() => attBillsCountByValue;

        /// <summary>
        /// Obtiene el saldo total de la alcanc�a.
        /// </summary>
        /// <returns>El saldo total de la alcanc�a.</returns>
        public double getTotalBalance()=> attTotalBalance;

        /// <summary>
        /// Obtiene la cantidad total de elementos de dinero en la alcanc�a (monedas y billetes).
        /// </summary>
        /// <returns>La cantidad total de elementos de dinero en la alcanc�a.</returns>
        public int getMoneyItemsCount() => attCoinsCount + attBillsCount;

        /// <summary>
        /// Obtiene la moneda de la alcanc�a.
        /// </summary>
        /// <returns>La moneda de la alcanc�a.</returns>
        public clsCurrency getCurrency() => attCurrency;
        #endregion
        #region Setters
        /// <summary>
        /// Establece la capacidad m�xima de monedas en la alcanc�a.
        /// </summary>
        /// <param name="prmValue">La nueva capacidad m�xima de monedas.</param>
        /// <returns>True si se estableci� correctamente; de lo contrario, false.</returns>
        private bool setCoinsMaxCapacity(int prmValue)
        {
            if (prmValue < 0) return false; 
            if (attCoinsCount > prmValue) return false; 
            attCoinsMaxCapacity = prmValue;
            return true;
        }

        /// <summary>
        /// Establece los valores de monedas aceptados por la alcanc�a.
        /// </summary>
        /// <param name="prmValues">La lista de valores de monedas aceptados.</param>
        /// <returns>True si se establecieron correctamente; de lo contrario, false.</returns>
        private bool setCoinsAcceptedValues(List<double> prmValues)
        {
            if(prmValues==null) return false; 
                for (int varIdx=0;  varIdx<attCoinsAcceptedValues.Count ; varIdx++)
                {
                    int varFoundedIndex= prmValues.IndexOf(attCoinsAcceptedValues[varIdx]);
                    if(varFoundedIndex == -1 && attCoinsCountByValue[varIdx]>0) return false;  //Domain Rule
                }
            attCoinsAcceptedValues = prmValues;
            attCoinsBalanceByValue = new List<double>(prmValues.Count);
            attCoinsCountByValue = new List<int>(prmValues.Count);
            return true;
            
        }

        /// <summary>
        /// Establece la capacidad m�xima de billetes en la alcanc�a.
        /// </summary>
        /// <param name="prmValue">La nueva capacidad m�xima de billetes.</param>
        /// <returns>True si se estableci� correctamente; de lo contrario, false.</returns>
        private bool setBillsMaxCapacity(int prmValue)
        {
            if (prmValue < 0) return false; 
            if (attBillsCount > prmValue) return false;
            attBillsMaxCapacity = prmValue;
            return true;
        }

        /// <summary>
        /// Establece los valores de billetes aceptados por la alcanc�a.
        /// </summary>
        /// <param name="prmValues">La lista de valores de billetes aceptados.</param>
        /// <returns>True si se establecieron correctamente; de lo contrario, false.</returns>
        private bool setBillsAcceptedValues(List<double> prmValues)
        {
            if (prmValues == null) return false; 
            for (int varIdx = 0; varIdx < attBillsAcceptedValues.Count; varIdx++)
            {
                int varFoundedIndex = prmValues.IndexOf(attBillsAcceptedValues[varIdx]);
                if (varFoundedIndex == -1 && attBillsCountByValue[varIdx] > 0) return false;  //Domain Rule
            }
            attBillsAcceptedValues = prmValues;
            attBillsBalanceByValue = new List<double>(prmValues.Count);
            attBillsCountByValue = new List<int>(prmValues.Count);
            return true;
        }

        /// <summary>
        /// Establece la moneda de la alcanc�a y ajusta los valores de monedas y billetes aceptados.
        /// </summary>
        /// <param name="prmObject">La nueva moneda de la alcanc�a.</param>
        /// <returns>True si se estableci� correctamente; de lo contrario, false.</returns>
        private bool setCurrency(clsCurrency prmObject)
        {
            if (prmObject==null) return false;
            if(attCoins.Count>0 && attBills.Count>0) return false; 
            if (attCurrency.CompareTo(prmObject) == 0) return false; 
            attCurrency =prmObject;
            setCoinsAcceptedValues(attCurrency.getCoinsValues());
            setBillsAcceptedValues(attCurrency.getBillsValues());

            return true;
        }
        /// <summary>
        /// Modifica los par�metros de la alcanc�a.
        /// </summary>
        /// <param name="prmCurrency">Moneda de la alcanc�a.</param>
        /// <param name="prmCoinsMaxCap">Capacidad m�xima de monedas en la alcanc�a.</param>
        /// <param name="prmBillsMaxCap">Capacidad m�xima de billetes en la alcanc�a.</param>
        /// <param name="prmCoinsValues">Valores de monedas aceptados por la alcanc�a.</param>
        /// <param name="prmBillsValues">Valores de billetes aceptados por la alcanc�a.</param>
        /// <returns>True si la modificaci�n fue exitosa; de lo contrario, false.</returns>
        public bool modify(clsCurrency prmCurrency,int prmCoinsMaxCap, int prmBillsMaxCap, List<double> prmCoinsValues, List<double> prmBillsValues)
        {
            if (setCoinsMaxCapacity(prmCoinsMaxCap))
                if (setBillsMaxCapacity(prmBillsMaxCap))
                    if (setCoinsAcceptedValues(prmCoinsValues))
                        if (setBillsAcceptedValues(prmBillsValues))
                            if (setCurrency(prmCurrency))
                                return true;
            return false;
        }
        #endregion
        #region Transactions
        /// <summary>
        /// Actualiza el saldo de la alcanc�a cuando se a�ade o retira una moneda.
        /// </summary>
        /// <param name="prmItem">La moneda que se a�ade o retira.</param>
        /// <param name="prmUp">True si se a�ade, False si se retira.</param>
        private void updateBalance(clsCoin prmItem,bool prmUp) 
        {
            int varFactor=(prmUp) ? 1 : -1;
            attTotalBalance += varFactor*prmItem.getValue();
            attCoinsCount+=varFactor;
            attCoinsBalance += varFactor * prmItem.getValue();
            int varIdxValue=clsCollections.getIndexOf(prmItem.getValue(),attCoinsAcceptedValues);
            attCoinsBalanceByValue[varIdxValue] += varFactor * prmItem.getValue();
            attCoinsCountByValue[varIdxValue] += varFactor; 
        }

        /// <summary>
        /// Actualiza el saldo de la alcanc�a cuando se a�ade o retira un billete.
        /// </summary>
        /// <param name="prmItem">El billete que se a�ade o retira.</param>
        /// <param name="prmUp">True si se a�ade, False si se retira.</param>
        private void updateBalance(clsBill prmItem,bool prmUp)
        {
            int varFactor = (prmUp) ? 1 : -1;
            attTotalBalance += varFactor * prmItem.getValue();
            attBillsCount += varFactor;
            attBillsBalance += varFactor * prmItem.getValue();
            int varIdxValue = clsCollections.getIndexOf(prmItem.getValue(), attBillsAcceptedValues);
            attBillsBalanceByValue[varIdxValue] += varFactor * prmItem.getValue();
            attBillsCountByValue[varIdxValue] += varFactor;

        }
        /// <summary>
        /// Verifica si una lista de monedas es aceptada por la alcanc�a.
        /// </summary>
        /// <param name="prmItems">La lista de monedas a verificar.</param>
        /// <returns>True si todas las monedas son aceptadas; de lo contrario, false.</returns>

        private bool areAccepted(List<clsCoin> prmItems)
        {
            foreach (clsCoin varObj in prmItems)
            {
                if (clsCollections.getIndexOf(varObj.getValue(),attCoinsAcceptedValues)==-1) return false;    
            }
            return true;
        }

        /// <summary>
        /// Verifica si una lista de billetes es aceptada por la alcanc�a.
        /// </summary>
        /// <param name="prmItems">La lista de billetes a verificar.</param>
        /// <returns>True si todos los billetes son aceptados; de lo contrario, false.</returns>
        private bool areAccepted(List<clsBill> prmItems)
        {
            foreach (clsBill varObj in prmItems)
            {
                if (clsCollections.getIndexOf(varObj.getValue(), attBillsAcceptedValues) == -1) return false;
            }
            return true;
        }

        /// <summary>
        /// Realiza un dep�sito de monedas en la alcanc�a.
        /// </summary>
        /// <param name="prmItems">La lista de monedas a depositar.</param>
        /// <returns>True si el dep�sito fue exitoso; de lo contrario, false.</returns>
        public bool coinsIncome(List<clsCoin> prmItems)
        {
            if (prmItems == null || prmItems.Count == 0) return false;
            if (prmItems.Count + attCoins.Count > attCoinsMaxCapacity) return false;                                
            if (!areAccepted(prmItems)) return false;
            foreach (clsCoin varObj in prmItems)
            { 
                attCoins.Add(varObj);
                varObj.setPiggy(this);
                updateBalance(varObj, true);
            }
            return true;
        }

        /// <summary>
        /// Retira monedas de la alcanc�a.
        /// </summary>
        /// <param name="prmItems">La lista de monedas a retirar.</param>
        /// <returns>True si la retirada fue exitosa; de lo contrario, false.</returns>
        public bool coinsWithdrawal(List<clsCoin> prmItems)
        {
            if (prmItems == null) return false; 
            foreach (clsCoin varObj in prmItems)
            { 
                attCoins.Remove(varObj);
                varObj.setPiggy(null);
                updateBalance(varObj, false);
            }
            return true;
        }

        /// <summary>
        /// Realiza un dep�sito de billetes en la alcanc�a.
        /// </summary>
        /// <param name="prmItems">La lista de billetes a depositar.</param>
        /// <returns>True si el dep�sito fue exitoso; de lo contrario, false.</returns>
        public bool billsIncome(List<clsBill> prmItems)
        {
            if (prmItems == null || prmItems.Count == 0) return false;
            if (prmItems.Count + attBills.Count > attBillsMaxCapacity) return false;
            if (!areAccepted(prmItems)) return false;
            foreach (clsBill varObj in prmItems)
            {
                attBills.Add(varObj);
                varObj.setPiggy(this);
                updateBalance(varObj, true);
            }
            return true;
        }

        /// <summary>
        /// Retira billetes de la alcanc�a.
        /// </summary>
        /// <param name="prmItems">La lista de billetes a retirar.</param>
        /// <returns>True si la retirada fue exitosa; de lo contrario, false.</returns>
        public bool billsWithdrawal(List<clsBill> prmItems)
        {
            if (prmItems == null) return false;
            foreach (clsBill varObj in prmItems)
            {
                attBills.Remove(varObj);
                varObj.setPiggy(null);
                updateBalance(varObj, false);
            }
            return true;
        }
        #endregion
        #region Utilities
        /// <summary>
        /// Compara la alcanc�a con otra alcanc�a bas�ndose en el m�todo CompareTo.
        /// </summary>
        /// <param name="prmOther">La alcanc�a con la que se compara.</param>
        /// <returns>Un valor entero que indica la relaci�n relativa entre las alcanc�as (0 si son iguales).</returns>
        public int CompareTo(clsPiggyBank prmOther)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Copia los atributos de la alcanc�a a otro objeto del mismo tipo.
        /// </summary>
        /// <typeparam name="T">El tipo del objeto al que se copian los atributos.</typeparam>
        /// <param name="prmOtherObject">El objeto al que se copian los atributos.</param>
        /// <returns>True si la copia fue exitosa; de lo contrario, false.</returns>
        public override bool copyTo<T>(T prmOtherObject)
        {
            clsPiggyBank varObjOther = prmOtherObject as clsPiggyBank;
            if (varObjOther != null) return false;
            attOID = varObjOther.attOID;
            attCoinsMaxCapacity = varObjOther.attCoinsMaxCapacity;
            attBillsMaxCapacity = varObjOther.attBillsMaxCapacity;
            attCoinsAcceptedValues = varObjOther.attCoinsAcceptedValues;
            attBillsAcceptedValues = varObjOther.attBillsAcceptedValues;
			attCurrency = varObjOther.attCurrency;
            return true;
        }

        /// <summary>
        /// Obtiene una representaci�n en formato de cadena de la informaci�n de la alcanc�a.
        /// </summary>
        /// <returns>Una cadena que representa la informaci�n detallada de la alcanc�a.</returns>
        public override string toString()
        {
            return "{Piggy Info}\n"
            +"{Coins Max Capacity}:\t" + attCoinsMaxCapacity + "\n"
            +"{Coins Accepted Values}:\t" + attCoinsAcceptedValues + "\n"
            +"{Coins Balance By Value}:\t" + attCoinsBalanceByValue + "\n"
            + "{Coins Count By Value}:\t" + attCoinsCountByValue + "\n"
            + "{Coins Balance}:\t" + attCoinsBalance + "\n"
            + "{Coins Count}:\t" + attCoinsCount + "\n"

            +"{Bills Max Capacity}:\t" + attBillsMaxCapacity + "\n"
            +"{Bills Accepted Values}:\t" + attBillsAcceptedValues + "\n"
            +"{Bills Balance By Value}:\t" + attBillsBalanceByValue + "\n"
            +"{Bills Count By Value}:\t" + attBillsCountByValue + "\n"
            +"{Bills Balance}:\t" + attBillsBalance + "\n"
            + "{Bills Count}:\t" + attBillsCount + "\n"

            + "{Total Balance}:\t" + attTotalBalance + "\n"
            +"{OID-Currency}" + attCurrency.getOID();
        }

        #endregion
        #region Destroyer
        /// <summary>
        /// Elimina la alcanc�a, retirando todas las monedas y billetes y desvincul�ndola de su moneda asociada.
        /// </summary>
        /// <returns>True si la eliminaci�n fue exitosa; de lo contrario, false.</returns>
        public override bool die()
        {
            if (attCoins == null) return false;
            if (attBills == null) return false;
            foreach (clsCoin varObj in attCoins)
            {
                varObj.setPiggy(null);
                this.attCoins.Remove(varObj);
            }
            foreach (clsBill varObj in attBills)
            {
                varObj.setPiggy(null);
                this.attBills.Remove(varObj);
            }
            attCurrency.setPiggyBank(null);
            this.setCurrency(null);
            return true;
        }
        #endregion
        #endregion
    }
}