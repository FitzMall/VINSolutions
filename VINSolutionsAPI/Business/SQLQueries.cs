using System;
using System.Collections.Generic;
using VINSolutionsAPI.Models;

namespace VINSolutionsAPI.Business
{
    public class SQLQueries
    {

        public static bool InsertOrUpdateDealers(IEnumerable<DealerModel> dealers)
        {
            var bSuccess = false;

            foreach (var dealer in dealers)
            {
                SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO [dbo].[Dealer] VALUES (@DealerID, @DealerName, @DealerBrands, @DealerAddress, @DealerCity, @DealerStateProvince, @DealerPostalCode, @DealerCountry, @RecordStatusCode, @LastUpdatedUTCDate)", 
                    new { DealerID = dealer.DealerID,
                        DealerName = dealer.DealerName,
                        DealerBrands = dealer.DealerBrands,
                        DealerAddress = dealer.DealerAddress,
                        DealerCity = dealer.DealerCity,
                        DealerStateProvince = dealer.DealerStateProvince,
                        DealerPostalCode = dealer.DealerPostalCode,
                        DealerCountry = dealer.DealerCountry,
                        RecordStatusCode = dealer.RecordStatusCode,
                        LastUpdatedUTCDate = dealer.LastUpdatedUTCDate
                    }, "JJFServer");
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateUsers(IEnumerable<UserModel> users)
        {
            var bSuccess = false;

            foreach (var user in users)
            {

                var existingUser = SqlMapperUtil.SqlWithParams<UserModel>("Select * from [dbo].[User] where UserID = @UserID", new { UserID = user.UserID }, "JJFServer");

                if (existingUser.Count == 0)
                {
                    SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO [dbo].[User] VALUES(@UserID,@FirstName,@LastName,@RecordStatusCode,@LastClockInUTCDate,@LastClockOutUTCDate,@LastMobileLoginDLTDate, @LastBrowserLoginDLTDate, @LastUpdatedUTCDate)",
                        new
                        {
                            UserID = user.UserID,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            RecordStatusCode = user.RecordStatusCode,
                            LastClockInUTCDate = user.LastClockInUTCDate,
                            LastClockOutUTCDate = user.LastClockOutUTCDate,
                            LastMobileLoginDLTDate = user.LastMobileLoginDLTDate,
                            LastBrowserLoginDLTDate = user.LastBrowserLoginDLTDate,
                            LastUpdatedUTCDate = user.LastUpdatedUTCDate
                        }, "JJFServer");
                }
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateUserAccess(IEnumerable<UserAccessModel> users)
        {
            var bSuccess = false;

            foreach (var user in users)
            {
                SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO[dbo].[UserAccess] VALUES(@DealerID,@UserID, @FirstName,@LastName,@InventoryAccessLevelID,@InventoryAccessLevelName,@CRMAccessLevelID,@CRMAccessLevelName,@SalesPersonInd,@InternetSalesPersonInd,@SalesManagerInd,@BDAgentInd,@CSIAgentInd,@ServiceAgentInd,@FinanceMgrInd,@UserGroupName,@RecordStatusCode,@LastUpdatedUTCDate)",
                        new
                        {
                            DealerID = user.DealerID,
                            UserID = user.UserID,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            InventoryAccessLevelID = user.InventoryAccessLevelID,
                            InventoryAccessLevelName = user.InventoryAccessLevelName,
                            CRMAccessLevelID = user.CRMAccessLevelID,
                            CRMAccessLevelName = user.CRMAccessLevelName,
                            SalesPersonInd = user.SalespersonInd,
                            InternetSalesPersonInd = user.InternetSalespersonInd,
                            SalesManagerInd = user.SalesManagerInd,
                            BDAgentInd = user.BDAgentInd,
                            CSIAgentInd = user.CSIAgentInd,
                            ServiceAgentInd = user.ServiceAgentInd,
                            FinanceMgrInd = user.FinanceMgrInd,
                            UserGroupName = user.UserGroupName,
                            RecordStatusCode = user.RecordStatusCode,
                            LastUpdatedUTCDate = user.LastUpdatedUTCDate

                        }, "JJFServer");
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateLeadSource(IEnumerable<LeadSourceModel> leadSource)
        {
            var bSuccess = false;

            foreach (var source in leadSource)
            {
                SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO[dbo].[LeadSource] VALUES (@DealerID,@LeadSourceID,@LeadTypeID,@LeadSourceName,@LeadSourceTypeName,@LeadSourceGroupName,@LastUpdatedUTCDate)",
                        new
                        {
                            DealerID = source.DealerID,
                            LeadSourceID = source.LeadSourceID,
                            LeadTypeID = source.LeadTypeID,
                            LeadSourceName = source.LeadSourceName,
                            LeadSourceTypeName = source.LeadSourceTypeName,
                            LeadSourceGroupName = source.LeadSourceGroupName,
                            LastUpdatedUTCDate = source.LastUpdatedUTCDate,                            
                        }, "JJFServer");
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateLeadStatus(IEnumerable<LeadStatusModel> leadStatus)
        {
            var bSuccess = false;

            foreach (var status in leadStatus)
            {
                SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO[dbo].[LeadStatus] VALUES(@LeadStatusID,@LeadStatusName,@LeadStatusTypeID,@LeadStatusTypeName,@LastUpdatedUTCDate)",
                        new
                        {
                            LeadStatusID = status.LeadStatusID,
                            LeadStatusName = status.LeadStatusName,
                            LeadStatusTypeID = status.LeadStatusTypeID,
                            LeadStatusTypeName = status.LeadStatusTypeName,
                            LastUpdatedUTCDate = status.LastUpdatedUTCDate
                        }, "JJFServer");
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateLeadStatusCustom(IEnumerable<LeadStatusCustomModel> leadStatus)
        {
            var bSuccess = false;

            foreach (var status in leadStatus)
            {
                SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO[dbo].[LeadStatusCustom] VALUES(@DealerID,@LeadStatusCustomID,@LeadStatusName,@LeadStatusTypeID,@LeadStatusTypeName,@LastUpdatedUTCDate)",
                        new
                        {
                            DealerID = status.DealerID,
                            LeadStatusCustomID = status.LeadStatusCustomID,
                            LeadStatusName = status.LeadStatusName,
                            LeadStatusTypeID = status.LeadStatusTypeID,
                            LeadStatusTypeName = status.LeadStatusTypeName,
                            LastUpdatedUTCDate = status.LastUpdatedUTCDate
                        }, "JJFServer");
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateAppointment(IEnumerable<AppointmentModel> appointments, ref string errorMessage)
        {
            var bSuccess = false;

            foreach (var appointment in appointments)
            {
                try
                {
                    SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO[dbo].[Appointment] VALUES(@DealerID,@AppointmentID,@CustomerID,@LeadID,@VisitID,@IsShow,@IsNoShow,@AppointmentType,@AssignedToUserID,@AppointmentStartUTCDate,@ScheduledUTCDate,@ScheduledByUserID,@ConfirmedUTCDate,@ConfirmedByUserID,@RescheduledUTCDate,@RescheduledByUserID,@CompletedUTCDate,@CompletedByUserID,@AppointmentStatus,@LastUpdatedByUserID,@LastUpdatedUTCDate )",
                            new
                            {
                                DealerID = appointment.DealerID,
                                AppointmentID = appointment.AppointmentID,
                                CustomerID = appointment.CustomerID,
                                LeadID = appointment.LeadID,
                                VisitID = appointment.VisitID,
                                IsShow = appointment.IsShow,
                                IsNoShow = appointment.IsNoShow,
                                AppointmentType = appointment.AppointmentType,
                                AssignedToUserID = appointment.AssignedToUserID,
                                AppointmentStartUTCDate = appointment.AppointmentStartUTCDate,
                                ScheduledUTCDate = appointment.ScheduledUTCDate,
                                ScheduledByUserID = appointment.ScheduledByUserID,
                                ConfirmedUTCDate = appointment.ConfirmedUTCDate,
                                ConfirmedByUserID = appointment.ConfirmedByUserID,
                                RescheduledUTCDate = appointment.RescheduledUTCDate,
                                RescheduledByUserID = appointment.RescheduledByUserID,
                                CompletedUTCDate = appointment.CompletedUTCDate,
                                CompletedByUserID = appointment.CompletedByUserID,
                                AppointmentStatus = appointment.AppointmentStatus,
                                LastUpdatedByUserID = appointment.LastUpdatedByUserID,
                                LastUpdatedUTCDate = appointment.LastUpdatedUTCDate

                            }, "JJFServer");
                }
                catch (Exception ex)
                {
                    errorMessage = "Appointments DB - " + ex.Message + "/n";
                }
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateCRMSoldTransaction(IEnumerable<CRMSoldTransactionModel> transactions, ref string errorMessage)
        {
            var bSuccess = false;

            foreach (var transaction in transactions)
            {
                try
                {
                    SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO[dbo].[CRMSoldTransaction] VALUES(@DealerID,@CustomerID,@LeadID,@DealNumber,@SalesRepUserID,@SplitSaleWithUserID,@InventoryType,@StockNumber,@VIN,@Year,@Make,@Model,@SalePrice,@FrontGross,@BackGross,@TotalGross,@PaymentMethod,@LeadFinanceSourceID,@DownPayment,@MonthlyPayment,@PaymentTermMonths,@FinanceMgrUserID,@FinanceCompanyName,@GAP,@CreditLife,@CreditDisability,@ExtendedWarranty,@CarCare,@RoadHazard,@FinanceReserve,@FinanceIncome,@ASIncome,@CRMDMSMatchInd,@RecordStatusCode,@OwnershipCode,@SoldUTCDate,@CreatedByUserID,@CreatedUTCDate,@LastUpdatedByUserID,@LastUpdatedUTCDate)",
                            new
                            {
                                DealerID = transaction.DealerID,
                                CustomerID = transaction.CustomerID,
                                LeadID = transaction.LeadID,
                                DealNumber = transaction.DealNumber,
                                SalesRepUserID = transaction.SalesRepUserID,
                                SplitSaleWithUserID = transaction.SplitSaleWithUserID,
                                InventoryType = transaction.InventoryType,
                                StockNumber = transaction.StockNumber,
                                VIN = transaction.VIN,
                                Year = transaction.Year,
                                Make = transaction.Make,
                                Model = transaction.Model,
                                SalePrice = transaction.SalePrice,
                                FrontGross = transaction.FrontGross,
                                BackGross = transaction.BackGross,
                                TotalGross = transaction.TotalGross,
                                PaymentMethod = transaction.PaymentMethod,
                                LeadFinanceSourceID = transaction.LeadFinanceSourceID,
                                DownPayment = transaction.DownPayment,
                                MonthlyPayment = transaction.MonthlyPayment,
                                PaymentTermMonths = transaction.PaymentTermMonths,
                                FinanceMgrUserID = transaction.FinanceMgrUserID,
                                FinanceCompanyName = transaction.FinanceCompanyName,
                                GAP = transaction.GAP,
                                CreditLife = transaction.CreditLife,
                                CreditDisability = transaction.CreditDisability,
                                ExtendedWarranty = transaction.ExtendedWarranty,
                                CarCare = transaction.CarCare,
                                RoadHazard = transaction.RoadHazard,
                                FinanceReserve = transaction.FinanceReserve,
                                FinanceIncome = transaction.FinanceIncome,
                                ASIncome = transaction.ASIncome,
                                CRMDMSMatchInd = transaction.CRMDMSMatchInd,
                                RecordStatusCode = transaction.RecordStatusCode,
                                OwnershipCode = transaction.OwnershipCode,
                                SoldUTCDate = transaction.SoldUTCDate,
                                CreatedByUserID = transaction.CreatedByUserID,
                                CreatedUTCDate = transaction.CreatedUTCDate,
                                LastUpdatedByUserID = transaction.LastUpdatedByUserID,
                                LastUpdatedUTCDate = transaction.LastUpdatedUTCDate

                            }, "JJFServer");
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "CRMSoldTransaction DB - " + ex.Message + "/n";
                }
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateDMSSoldTransaction(IEnumerable<DMSSoldTransactionModel> transactions, ref string errorMessage)
        {
            var bSuccess = false;

            foreach (var transaction in transactions)
            {
                try
                { 
                SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO [dbo].[DMSSoldTransaction] VALUES (@DealerID,@DealNumber,@CustomerID,@DMSSaleID,@CRMSaleID,@ContractType,@SaleType,@PurchaseOrderDate,@ContractDate,@DeliveryDate,@ReversalDate,@DealStatusDate,@DealStatus,@Comments,@Wholesale,@InventoryType,@VehicleTypeID,@StockNumber,@VIN,@Year,@Make,@Model,@Trim,@Color,@BodyStyle,@Transmission,@Engine,@ModelCode,@EstimatedOdometer,@OdometerLimit,@ListPrice,@InvoicePrice,@SalePrice,@HoldbackAmount,@PackAmount,@Cost,@ReconditioningCost,@TotalSaleCreditAmount,@PickupPayment,@CashDownPayment,@RebateAmount,@Taxes,@Accessories,@FeesAndAccessories,@AllowanceAmount,@TradeInActualCashValue,@TradePayoff,@NetTradeAmount,@FrontGross,@BackGross,@TotalGross,@SecurityDeposit,@DriveOffAmount,@NetCapitalizedCost,@DeliveryOdometer,@TotalFinanceAmount,@APR,@FinanceCharge,@ContractTerm,@MonthlyPayment,@TotalOfPayments,@PaymentFrequency,@FirstPaymentDate,@ExpectedPayoffDate,@BalloonPayment,@FinanceCompanyCode,@FinanceCompanyName,@BuyRate,@TermDepreciationValue,@GAPPrice,@GAPCost,@CreditInsurancePrice,@CreditInsuranceCost,@AHPrice,@AHCost,@FinanceReserve,@NetFinanceReservce,@BaseMonthlyPayment,@MonthlyTax,@WeOweFront,@WeOweFrontCost,@WeOweBack,@WeOweBackCost,@WarrantyPrice,@WarrantyCost,@WarrantyOdometerLimit,@WarrantyDeductible,@WarrantyCarrier,@WarrantyPolicyNumber,@WarrantyTerm,@BuyerID,@BuyerFirstName,@BuyerMiddleName,@BuyerLastName,@BuyerFullName,@BuyerHomeAddress,@BuyerCity,@BuyerStateProvince,@BuyerPostalCode,@BuyerHomePhoneNumber,@BuyerBusinessPhoneNumber,@BuyerCellPhoneNumber,@BuyerEmailAddress,@BuyerEntityType,@BuyerCompanyName,@CoBuyerID,@CoBuyerFirstName,@CoBuyerMiddleName,@CoBuyerLastName,@CoBuyerFullName,@CoBuyerHomeAddress,@CoBuyerCity,@CoBuyerStateProvince,@CoBuyerPostalCode,@CoBuyerHomePhoneNumber,@CoBuyerBusinessPhoneNumber,@CoBuyerCellPhoneNumber,@CoBuyerEmailAddress,@CoBuyerEntityType,@CoBuyerCompanyName,@SalesPersonID,@SalesPersonFirstName,@SalesPersonMiddleName,@SalesPersonLastName,@SalesPersonFullName,@SplitSalesPersonID,@SplitSalesPersonFirstName,@SplitSalesPersonMiddleName,@SplitSalesPersonLastName,@SplitSalesPersonFullName,@Trade1StockNumber,@Trade1VIN,@Trade1Year,@Trade1Make,@Trade1Model,@Trade1Color,@Trade1Odometer,@Trade1Allowance,@Trade1Payoff,@Trade1Net,@Trade1OverAllowance,@Trade1ActualCashValue,@Trade2StockNumber,@Trade2VIN,@Trade2Year,@Trade2Make,@Trade2Model,@Trade2Color,@Trade2Odometer,@Trade2Allowance,@Trade2Payoff,@Trade2Net,@Trade2OverAllowance,@Trade2ActualCashValue,@FinanceManagerDMSID,@SalesManagerDMSID,@ClosingManagerDMSID,@DeskManagerDMSID,@VSSaleType,@RecordStatusCode,@NoLongerOwnsVehicle,@CreateUTCDate,@LastUpdatedUTCDate)",
                        new
                        {
                            DealerID = transaction.DealerID,
                            DealNumber = transaction.DealNumber,
                            CustomerID = transaction.CustomerID,
                            DMSSaleID = transaction.DMSSaleID,
                            CRMSaleID = transaction.CRMSaleID,
                            ContractType = transaction.ContractType,
                            SaleType = transaction.SaleType,
                            PurchaseOrderDate = transaction.PurchaseOrderDate,
                            ContractDate = transaction.ContractDate,
                            DeliveryDate = transaction.DeliveryDate,
                            ReversalDate = transaction.ReversalDate,
                            DealStatusDate = transaction.DealStatusDate,
                            DealStatus = transaction.DealStatus,
                            Comments = transaction.Comments,
                            Wholesale = transaction.Wholesale,
                            InventoryType = transaction.InventoryType,
                            VehicleTypeID = transaction.VehicleTypeID,
                            StockNumber = transaction.StockNumber,
                            VIN = transaction.VIN,
                            Year = transaction.Year,
                            Make = transaction.Make,
                            Model = transaction.Model,
                            Trim = transaction.Trim,
                            Color = transaction.Color,
                            BodyStyle = transaction.BodyStyle,
                            Transmission = transaction.Transmission,
                            Engine = transaction.Engine,
                            ModelCode = transaction.ModelCode,
                            EstimatedOdometer = transaction.EstimatedOdometer,
                            OdometerLimit = transaction.OdometerLimit,
                            ListPrice = transaction.ListPrice,
                            InvoicePrice = transaction.InvoicePrice,
                            SalePrice = transaction.SalePrice,
                            HoldbackAmount = transaction.HoldBackAmount,
                            PackAmount = transaction.PackAmount,
                            Cost = transaction.Cost,
                            ReconditioningCost = transaction.ReconditioningCost,
                            TotalSaleCreditAmount = transaction.TotalSaleCreditAmount,
                            PickupPayment = transaction.PickupPayment,
                            CashDownPayment = transaction.CashDownPayment,
                            RebateAmount = transaction.RebateAmount,
                            Taxes = transaction.Taxes,
                            Accessories = transaction.Accessories,
                            FeesAndAccessories = transaction.FeesAndAccessories,
                            AllowanceAmount = transaction.AllowanceAmount,
                            TradeInActualCashValue = transaction.TradeInActualCashValue,
                            TradePayoff = transaction.TradePayoff,
                            NetTradeAmount = transaction.NetTradeAmount,
                            FrontGross = transaction.FrontGross,
                            BackGross = transaction.BackGross,
                            TotalGross = transaction.TotalGross,
                            SecurityDeposit = transaction.SecurityDeposit,
                            DriveOffAmount = transaction.DriveOffAmount,
                            NetCapitalizedCost = transaction.NetCapitalizedCost,
                            DeliveryOdometer = transaction.DeliveryOdometer,
                            TotalFinanceAmount = transaction.TotalFinanceAmount,
                            APR = transaction.APR,
                            FinanceCharge = transaction.FinanceCharge,
                            ContractTerm = transaction.ContractTerm,
                            MonthlyPayment = transaction.MonthlyPayment,
                            TotalOfPayments = transaction.TotalOfPayments,
                            PaymentFrequency = transaction.PaymentFrequency,
                            FirstPaymentDate = transaction.FirstPaymentDate,
                            ExpectedPayoffDate = transaction.ExpectedPayoffDate,
                            BalloonPayment = transaction.BalloonPayment,
                            FinanceCompanyCode = transaction.FinanceCompanyCode,
                            FinanceCompanyName = transaction.FinanceCompanyName,
                            BuyRate = transaction.BuyRate,
                            TermDepreciationValue = transaction.TermDepreciationValue,
                            GAPPrice = transaction.GapPrice,
                            GAPCost = transaction.GapCost,
                            CreditInsurancePrice = transaction.CreditInsurancePrice,
                            CreditInsuranceCost = transaction.CreditInsuranceCost,
                            AHPrice = transaction.AHPrice,
                            AHCost = transaction.AHCost,
                            FinanceReserve = transaction.FinanceReserve,
                            NetFinanceReservce = transaction.NetFinanceReserve,
                            BaseMonthlyPayment = transaction.BaseMonthlyPayment,
                            MonthlyTax = transaction.MonthlyTax,
                            WeOweFront = transaction.WeOweFront,
                            WeOweFrontCost = transaction.WeOweFrontCost,
                            WeOweBack = transaction.WeOweBack,
                            WeOweBackCost = transaction.WeOweBackCost,
                            WarrantyPrice = transaction.WarrantyPrice,
                            WarrantyCost = transaction.WarrantyCost,
                            WarrantyOdometerLimit = transaction.WarrantyOdometerLimit,
                            WarrantyDeductible = transaction.WarrantyDeductible,
                            WarrantyCarrier = transaction.WarrantyCarrier,
                            WarrantyPolicyNumber = transaction.WarrantyPolicyNumber,
                            WarrantyTerm = transaction.WarrantyTerm,
                            BuyerID = transaction.BuyerID,
                            BuyerFirstName = transaction.BuyerFirstName,
                            BuyerMiddleName = transaction.BuyerMiddleName,
                            BuyerLastName = transaction.BuyerLastName,
                            BuyerFullName = transaction.BuyerFullName,
                            BuyerHomeAddress = transaction.BuyerHomeAddress,
                            BuyerCity = transaction.BuyerCity,
                            BuyerStateProvince = transaction.BuyerStateProvince,
                            BuyerPostalCode = transaction.BuyerPostalCode,
                            BuyerHomePhoneNumber = transaction.BuyerHomePhoneNumber,
                            BuyerBusinessPhoneNumber = transaction.BuyerBusinessPhoneNumber,
                            BuyerCellPhoneNumber = transaction.BuyerCellPhoneNumber,
                            BuyerEmailAddress = transaction.BuyerEmailAddress,
                            BuyerEntityType = transaction.BuyerEntityType,
                            BuyerCompanyName = transaction.BuyerCompanyName,
                            CoBuyerID = transaction.CoBuyerID,
                            CoBuyerFirstName = transaction.CoBuyerFirstName,
                            CoBuyerMiddleName = transaction.CoBuyerMiddleName,
                            CoBuyerLastName = transaction.CoBuyerLastName,
                            CoBuyerFullName = transaction.CoBuyerFullName,
                            CoBuyerHomeAddress = transaction.CoBuyerHomeAddress,
                            CoBuyerCity = transaction.CoBuyerCity,
                            CoBuyerStateProvince = transaction.CoBuyerStateProvince,
                            CoBuyerPostalCode = transaction.CoBuyerPostalCode,
                            CoBuyerHomePhoneNumber = transaction.CoBuyerHomePhoneNumber,
                            CoBuyerBusinessPhoneNumber = transaction.CoBuyerBusinessPhoneNumber,
                            CoBuyerCellPhoneNumber = transaction.CoBuyerCellPhoneNumber,
                            CoBuyerEmailAddress = transaction.CoBuyerEmailAddress,
                            CoBuyerEntityType = transaction.CoBuyerEntityType,
                            CoBuyerCompanyName = transaction.CoBuyerCompanyName,
                            SalesPersonID = transaction.SalesPersonID,
                            SalesPersonFirstName = transaction.SalesPersonFirstName,
                            SalesPersonMiddleName = transaction.SalesPersonMiddleName,
                            SalesPersonLastName = transaction.SalesPersonLastName,
                            SalesPersonFullName = transaction.SalesPersonFullName,
                            SplitSalesPersonID = transaction.SplitSalespersonID,
                            SplitSalesPersonFirstName = transaction.SplitSalespersonFirstName,
                            SplitSalesPersonMiddleName = transaction.SplitSalespersonMiddleName,
                            SplitSalesPersonLastName = transaction.SplitSalespersonLastName,
                            SplitSalesPersonFullName = transaction.SplitSalespersonFullName,
                            Trade1StockNumber = transaction.Trade1StockNumber,
                            Trade1VIN = transaction.Trade1VIN,
                            Trade1Year = transaction.Trade1Year,
                            Trade1Make = transaction.Trade1Make,
                            Trade1Model = transaction.Trade1Model,
                            Trade1Color = transaction.Trade1Color,
                            Trade1Odometer = transaction.Trade1Odometer,
                            Trade1Allowance = transaction.Trade1Allowance,
                            Trade1Payoff = transaction.Trade1Payoff,
                            Trade1Net = transaction.Trade1Net,
                            Trade1OverAllowance = transaction.Trade1OverAllowance,
                            Trade1ActualCashValue = transaction.Trade1ActualCashValue,
                            Trade2StockNumber = transaction.Trade2StockNumber,
                            Trade2VIN = transaction.Trade2VIN,
                            Trade2Year = transaction.Trade2Year,
                            Trade2Make = transaction.Trade2Make,
                            Trade2Model = transaction.Trade2Model,
                            Trade2Color = transaction.Trade2Color,
                            Trade2Odometer = transaction.Trade2Odometer,
                            Trade2Allowance = transaction.Trade2Allowance,
                            Trade2Payoff = transaction.Trade2Payoff,
                            Trade2Net = transaction.Trade2Net,
                            Trade2OverAllowance = transaction.Trade2OverAllowance,
                            Trade2ActualCashValue = transaction.Trade2ActualCashValue,
                            FinanceManagerDMSID = transaction.FinanceManagerDMSID,
                            SalesManagerDMSID = transaction.SalesManagerDMSID,
                            ClosingManagerDMSID = transaction.ClosingManagerDMSID,
                            DeskManagerDMSID = transaction.DeskManagerDMSID,
                            VSSaleType = transaction.VSSaleType,
                            RecordStatusCode = transaction.RecordStatusCode,
                            NoLongerOwnsVehicle = transaction.NoLongerOwnsVehicle,
                            CreateUTCDate = transaction.CreatedUTCDate,
                            LastUpdatedUTCDate = transaction.LastUpdatedUTCDate
                        }, "JJFServer");
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "DMSSoldTransaction DB - " + ex.Message + "/n";
                }
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateCustomer(IEnumerable<CustomerModel> customers, ref string errorMessage)
        {
            var bSuccess = false;

            foreach (var customer in customers)
            {
                try
                {
                    SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO [dbo].[Customer] VALUES(@DealerID,@CustomerID,@CustomerType,@CustomerStatus, @CustomerFirstName,@CustomerMiddleName,@CustomerLastName,@CompanyName,@SalesMgrUserID,@SalesRepUserID,@SplitSalesRepUserID,@BDAgentUserID,@CSIAgentUserID,@IsSalesCustomer,@IsServiceCustomer,@LastInboundContactUTCDate,@LastOutboundContactUTCDate,@PostalCode,@DayTimePhone,@DayTimePhoneExt,@EveningPhone,@EveningPhoneExt,@CellPhone,@Fax,@Email,@AlternateEmail,@DoNotMail,@CanBeMailed,@DoNotCall,@CanBeCalled,@DoNotEmail,@CanBeEmailed,@EBR,@EBRSource,@EBRDate,@EBRExpiration,@ExpressConsent,@ExpressConsentSource,@CompliancePreferredEmail,@ExpressConsentLastModifiedUTCDate,@ExpressConsentLastModifiedByUser,@CanText,@CreatedUTCDate,@LastUpdatedUTCDate)",
                            new
                            {
                                DealerID = customer.DealerID,
                                CustomerID = customer.CustomerID,
                                CustomerType = customer.CustomerType,
                                CustomerStatus = customer.CustomerStatus,
                                CustomerFirstName = customer.CustomerFirstName,
                                CustomerMiddleName = customer.CustomerMiddleName,
                                CustomerLastName = customer.CustomerLastName,
                                CompanyName = customer.CompanyName,
                                SalesMgrUserID = customer.SalesMgrUserID,
                                SalesRepUserID = customer.SalesRepUserID,
                                SplitSalesRepUserID = customer.SplitSalesRepUserID,
                                BDAgentUserID = customer.BDAgentUserID,
                                CSIAgentUserID = customer.CSIAgentUserID,
                                IsSalesCustomer = customer.IsSalesCustomer,
                                IsServiceCustomer = customer.IsServiceCustomer,
                                LastInboundContactUTCDate = customer.LastInboundContactUTCDate,
                                LastOutboundContactUTCDate = customer.LastOutboundContactUTCDate,
                                PostalCode = customer.PostalCode,
                                DayTimePhone = customer.DayTimePhone,
                                DayTimePhoneExt = customer.DayTimePhoneExt,
                                EveningPhone = customer.EveningPhone,
                                EveningPhoneExt = customer.EveningPhoneExt,
                                CellPhone = customer.CellPhone,
                                Fax = customer.Fax,
                                Email = customer.Email,
                                AlternateEmail = customer.AlternateEmail,
                                DoNotMail = customer.DoNotMail,
                                CanBeMailed = customer.CanBeMailed,
                                DoNotCall = customer.DoNotCall,
                                CanBeCalled = customer.CanBeCalled,
                                DoNotEmail = customer.DoNotEmail,
                                CanBeEmailed = customer.CanBeEmailed,
                                EBR = customer.EBR,
                                EBRSource = customer.EBRSource,
                                EBRDate = customer.EBRDate,
                                EBRExpiration = customer.EBRExpiration,
                                ExpressConsent = customer.ExpressConsent,
                                ExpressConsentSource = customer.ExpressConsentSource,
                                CompliancePreferredEmail = customer.CompliancePreferredEmail,
                                ExpressConsentLastModifiedUTCDate = customer.ExpressConsentLastModifiedUTCDate,
                                ExpressConsentLastModifiedByUser = customer.ExpressConsentLastModifiedByUser,
                                CanText = customer.CanText,
                                CreatedUTCDate = customer.CreatedUTCDate,
                                LastUpdatedUTCDate = customer.LastUpdatedUTCDate

                            }, "JJFServer");
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "Customer DB - " + ex.Message + "/n";
                }
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateInventory(IEnumerable<InventoryModel> inventory, ref string errorMessage)
        {
            var bSuccess = false;

            foreach (var vehicle in inventory)
            {
                try
                { 
                SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO [dbo].[Inventory] VALUES( @DealerID, @VehicleID, @VIN, @StockNumber, @InventoryType, @Year, @Make, @Model, @Trim, @Odometer, @Price, @InternetPrice, @ComparePrice, @Cost, @PhotoCount, @HasVideo, @HasCarfax, @HasComments, @VehicleType, @RecordStatusCode, @InventoryUTCDate, @RemovalUTCDate, @LastUpdatedUTCDate)",
                        new
                        {
                            DealerID = vehicle.DealerID,
                            VehicleID = vehicle.VehicleID,
                            VIN = vehicle.VIN,
                            StockNumber = vehicle.StockNumber,
                            InventoryType = vehicle.InventoryType,
                            Year = vehicle.Year,
                            Make = vehicle.Make,
                            Model = vehicle.Model,
                            Trim = vehicle.Trim,
                            Odometer = vehicle.Odometer,
                            Price = vehicle.Price,
                            InternetPrice = vehicle.InternetPrice,
                            ComparePrice = vehicle.ComparePrice,
                            Cost = vehicle.Cost,
                            PhotoCount = vehicle.PhotoCount,
                            HasVideo = vehicle.HasVideo,
                            HasCarfax = vehicle.HasCarfax,
                            HasComments = vehicle.HasComments,
                            VehicleType = vehicle.VehicleType,
                            RecordStatusCode = vehicle.RecordStatusCode,
                            InventoryUTCDate = vehicle.InventoryUTCDate,
                            RemovalUTCDate = vehicle.RemovalUTCDate,
                            LastUpdatedUTCDate = vehicle.LastUpdatedUTCDate
                        }, "JJFServer");
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "Inventory DB - " + ex.Message + "/n";
                }
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateLead(IEnumerable<LeadModel> leads, ref string errorMessage)
        {
            var bSuccess = false;

            foreach (var lead in leads)
            {
                try
                { 
                SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO [dbo].[Lead] VALUES ( @DealerID, @LeadID, @CustomerID, @SalesRepUserID, @LeadSourceID, @LeadTypeID, @LeadStatusID, @LeadStatusCustomID, @LeadStatusTypeID, @ADFXML, @FirstAttemptedContactUTCDate, @LastAttemptedContactUTCDate, @LastAttemptedEmailContactUTCDate, @LastAttemptedPhoneContactUTCDate, @LastCustomerContactUTCDate, @LastAttemptedOrActualContactUTCDate, @DealerActionableUTCDate, @HasBeenContacted, @HasVehicleOfInterest, @OriginatedAfterHours, @AdjustedResponseTimeInMinutes, @ActualResponseTimeInMinutes, @OriginationUTCDate, @LastUpdatedUTCDate)",
                        new
                        {
                            DealerID = lead.DealerID,
                            LeadID = lead.LeadID,
                            CustomerID = lead.CustomerID,
                            SalesRepUserID = lead.SalesRepUserID,
                            LeadSourceID = lead.LeadSourceID,
                            LeadTypeID = lead.LeadTypeID,
                            LeadStatusID = lead.LeadStatusID,
                            LeadStatusCustomID = lead.LeadStatusCustomID,
                            LeadStatusTypeID = lead.LeadStatusTypeID,
                            ADFXML = lead.ADFXML,
                            FirstAttemptedContactUTCDate = lead.FirstAttemptedContactUTCDate,
                            LastAttemptedContactUTCDate = lead.LastAttemptedContactUTCDate,
                            LastAttemptedEmailContactUTCDate = lead.LastAttemptedEmailContactUTCDate,
                            LastAttemptedPhoneContactUTCDate = lead.LastAttemptedPhoneContactUTCDate,
                            LastCustomerContactUTCDate = lead.LastCustomerContactUTCDate,
                            LastAttemptedOrActualContactUTCDate = lead.LastAttemptedOrActualContactUTCDate,
                            DealerActionableUTCDate = lead.DealerActionableUTCDate,
                            HasBeenContacted = lead.HasBeenContacted,
                            HasVehicleOfInterest = lead.HasVehicleOfInterest,
                            OriginatedAfterHours = lead.OriginatedAfterHours,
                            AdjustedResponseTimeInMinutes = lead.AdjustedResponseTimeInMinutes,
                            ActualResponseTimeInMinutes = lead.ActualResponseTimeInMinutes,
                            OriginationUTCDate = lead.OriginationUTCDate,
                            LastUpdatedUTCDate = lead.LastUpdatedUTCDate
                        }, "JJFServer");
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "Lead DB - " + ex.Message + "/n";
                }
            }
            return bSuccess;
        }

        
        public static bool InsertOrUpdateLeadTradeInVehicle(IEnumerable<LeadTradeInVehicleModel> vehicles, ref string errorMessage)
        {
            var bSuccess = false;

            foreach (var vehicle in vehicles)
            {
                try
                { 
                SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO [dbo].[LeadTradeInVehicle] VALUES ( @DealerID, @CustomerID, @LeadID, @TradeInID, @VIN, @Year, @Make, @Model, @Trim, @InteriorColor, @ExteriorColor, @Odometer, @RecordStatusCode, @TradePayoff, @TradeACV, @TradeAllowance, @AppraisalByUserID, @LastUpdatedUTCDate)",
                        new
                        {
                            DealerID = vehicle.DealerID,
                            CustomerID = vehicle.CustomerID,
                            LeadID = vehicle.LeadID,
                            TradeInID = vehicle.TradeInID,
                            VIN = vehicle.VIN,
                            Year = vehicle.Year,
                            Make = vehicle.Make,
                            Model = vehicle.Model,
                            Trim = vehicle.Trim,
                            InteriorColor = vehicle.InteriorColor,
                            ExteriorColor = vehicle.ExteriorColor,
                            Odometer = vehicle.Odometer,
                            RecordStatusCode = vehicle.RecordStatusCode,
                            TradePayoff = vehicle.TradePayoff,
                            TradeACV = vehicle.TradeACV,
                            TradeAllowance = vehicle.TradeAllowance,
                            AppraisalByUserID = vehicle.AppraisalByUserID,
                            LastUpdatedUTCDate = vehicle.LastUpdatedUTCDate

                        }, "JJFServer");
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "LeadTradeInVehicle DB - " + ex.Message + "/n";
                }
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateLeadVehicleOfInterest(IEnumerable<LeadVehicleOfInterestModel> vehicles, ref string errorMessage)
        {
            var bSuccess = false;

            foreach (var vehicle in vehicles)
            {
                try
                { 
                SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO [dbo].[LeadVehicleOfInterest] VALUES ( @DealerID, @LeadVehicleOfInterestID, @LeadID, @AutoID, @InventoryType, @StockNumber, @VIN, @Year, @Make, @Model, @Trim, @InteriorColor, @ExteriorColor, @Odometer, @Price, @IsPrimary, @RecordStatusCode, @LastUpdatedUTCDate)",
                        new
                        {
                            DealerID = vehicle.DealerID,
                            LeadVehicleOfInterestID = vehicle.VehicleOfInterestID,
                            LeadID = vehicle.LeadID,
                            AutoID = vehicle.AutoID,
                            InventoryType = vehicle.InventoryType,
                            StockNumber = vehicle.StockNumber,
                            VIN = vehicle.VIN,
                            Year = vehicle.Year,
                            Make = vehicle.Make,
                            Model = vehicle.Model,
                            Trim = vehicle.Trim,
                            InteriorColor = vehicle.InteriorColor,
                            ExteriorColor = vehicle.ExteriorColor,
                            Odometer = vehicle.Odometer,
                            Price = vehicle.Price,
                            IsPrimary = vehicle.IsPrimary,
                            RecordStatusCode = vehicle.RecordStatusCode,
                            LastUpdatedUTCDate = vehicle.LastUpdatedUTCDate

                        }, "JJFServer");
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "LeadVehicleOfInterest DB - " + ex.Message + "/n";
                }
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateServiceVisit(IEnumerable<ServiceVisitModel> visits, ref string errorMessage)
        {
            var bSuccess = false;

            foreach (var visit in visits)
            {
                try
                { 
                SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO [dbo].[ServiceVisit] VALUES ( @DealerID, @CustomerID, @RepairOrderID, @RepairOrderNumber, @VIN, @Odometer, @ServiceAdvisorUserID, @ServiceAdvisorName, @PartsTotal, @LaborTotal, @TotalServiceHours, @LaborDescription, @LaborLineCount, @DealerPaidAmount, @CustomerPaidAmount, @WarrantyPaidAmount, @TotalPaidAmount, @ROOpenedDate, @ROClosedDate, @LastUpdatedUTCDate)",
                        new
                        {
                            DealerID = visit.DealerID,
                            CustomerID = visit.CustomerID,
                            RepairOrderID = visit.RepairOrderID,
                            RepairOrderNumber = visit.RepairOrderNumber,
                            VIN = visit.VIN,
                            Odometer = visit.Odometer,
                            ServiceAdvisorUserID = visit.ServiceAdvisorUserID,
                            ServiceAdvisorName = visit.ServiceAdvisorName,
                            PartsTotal = visit.PartsTotal,
                            LaborTotal = visit.LaborTotal,
                            TotalServiceHours = visit.TotalServiceHours,
                            LaborDescription = visit.LaborDescription,
                            LaborLineCount = visit.LaborLineCount,
                            DealerPaidAmount = visit.DealerPaidAmount,
                            CustomerPaidAmount = visit.CustomerPaidAmount,
                            WarrantyPaidAmount = visit.WarrantyPaidAmount,
                            TotalPaidAmount = visit.TotalPaidAmount,
                            ROOpenedDate = visit.ROOpenedDate,
                            ROClosedDate = visit.ROClosedDate,
                            LastUpdatedUTCDate = visit.LastUpdatedUTCDate

                        }, "JJFServer");
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "ServiceVisit DB - " + ex.Message + "/n";
                }
            }
            return bSuccess;
        }


        public static bool InsertOrUpdateShowroomVisit(IEnumerable<ShowroomVisitModel> visits, ref string errorMessage)
        {
            var bSuccess = false;

            foreach (var visit in visits)
            {
                try
                { 
                SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO [dbo].[ShowroomVisit] VALUES ( @DealerID, @VisitID, @LeadID, @CreatedByUserID, @CompletedByUserID, @TurnoverManagerUserID, @StartUTCDate, @EndUTCDate, @EndReasonID, @EndReasonDescription, @ResultID, @ResultDescription, @BeBack, @LeadMessageType, @ContactedAfterVisit, @WalkAround, @TradeAppraisal, @DemoTestDrive, @WriteUp, @ManagerTurnOver, @AftermarketTurnOver, @FinanceTurnOver, @Desking, @Custom1, @Custom2, @Custom3, @Custom4, @Custom5, @Custom6, @Custom7, @DeletedFlag, @LastUpdatedUTCDate )",
                        new
                        {
                            DealerID = visit.DealerID,
                            VisitID = visit.VisitID,
                            LeadID = visit.LeadID,
                            CreatedByUserID = visit.CreatedByUserID,
                            CompletedByUserID = visit.CompletedByUserID,
                            TurnoverManagerUserID = visit.TurnOverManagerUserID,
                            StartUTCDate = visit.StartUTCDate,
                            EndUTCDate = visit.EndUTCDate,
                            EndReasonID = visit.EndReasonID,
                            EndReasonDescription = visit.EndReasonDescription,
                            ResultID = visit.ResultID,
                            ResultDescription = visit.ResultDescription,
                            BeBack = visit.BeBack,
                            LeadMessageType = visit.LeadMessageType,
                            ContactedAfterVisit = visit.ContactedAfterVisit,
                            WalkAround = visit.WalkAround,
                            TradeAppraisal = visit.TradeAppraisal,
                            DemoTestDrive = visit.DemoTestDrive,
                            WriteUp = visit.WriteUp,
                            ManagerTurnOver = visit.ManagerTurnOver,
                            AftermarketTurnOver = visit.AfterMarketTurnOver,
                            FinanceTurnOver = visit.FinanceTurnOver,
                            Desking = visit.Desking,
                            Custom1 = visit.Custom1,
                            Custom2 = visit.Custom2,
                            Custom3 = visit.Custom3,
                            Custom4 = visit.Custom4,
                            Custom5 = visit.Custom5,
                            Custom6 = visit.Custom6,
                            Custom7 = visit.Custom7,
                            DeletedFlag = visit.DeletedFlag,
                            LastUpdatedUTCDate = visit.LastUpdatedUTCDate
                        }, "JJFServer");
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "ShowroomVisit DB - " + ex.Message + "/n";
                }
            }
            return bSuccess;
        }

        public static bool InsertOrUpdateTask(IEnumerable<TaskModel> tasks, ref string errorMessage)
        {
            var bSuccess = false;

            foreach (var task in tasks)
            {
                try
                { 
                SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO [dbo].[Task] VALUES ( @DealerID, @CustomerID, @TaskID, @LeadID, @TaskCreatedUTCDate, @TaskStatusCode, @TaskStatus, @DueUTCDate, @TaskUserTypeCode,  @TaskUserTypeDescription, @TaskTypeID, @TaskTypeDescription, @IsOverdue, @IsImportant, @IsUserGenerated, @ProcessTypeID, @ProcessType, @ProcessSubTypeID, @ProcessSubType, @RepairOrderID, @MissedUserID, @DismissedUserID, @AssignedToUserID, @LastUpdatedUTCDate )",
                        new
                        {
                            DealerID = task.DealerID,
                            CustomerID = task.CustomerID,
                            TaskID = task.TaskID,
                            LeadID = task.LeadID,
                            TaskCreatedUTCDate = task.TaskCreatedUTCDate,
                            TaskStatusCode = task.TaskStatusCode,
                            TaskStatus = task.TaskStatus,
                            DueUTCDate = task.DueUTCDate,
                            TaskUserTypeCode = task.TaskUserTypeCode,
                            TaskUserTypeDescription = task.TaskUserTypeDescription,
                            TaskTypeID = task.TaskTypeID,
                            TaskTypeDescription = task.TaskTypeDescription,
                            IsOverdue = task.IsOverdue,
                            IsImportant = task.IsImportant,
                            IsUserGenerated = task.IsUserGenerated,
                            ProcessTypeID = task.ProcessTypeID,
                            ProcessType = task.ProcessType,
                            ProcessSubTypeID = task.ProcessSubTypeID,
                            ProcessSubType = task.ProcessSubType,
                            RepairOrderID = task.RepairOrderID,
                            MissedUserID = task.MissedUserID,
                            DismissedUserID = task.DismissedUserID,
                            AssignedToUserID = task.AssignedToUserID,
                            LastUpdatedUTCDate = task.LastUpdatedUTCDate
                        }, "JJFServer");
                }
                catch (Exception ex)
                {
                    errorMessage = errorMessage + "Task DB - " + ex.Message + "/n";
                }
            }
            return bSuccess;
        }

    }
}