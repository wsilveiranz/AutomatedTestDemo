using Microsoft.Azure.Workflows.UnitTesting.Definitions;
using Microsoft.Azure.Workflows.UnitTesting.ErrorResponses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System;

namespace LogicApps.Tests.Mocks.sample_workflow
{
    /// <summary>
    /// The <see cref="ListRowsActionMock"/> class.
    /// </summary>
    public class ListRowsActionMock : ActionMock
    {
        /// <summary>
        /// Creates a mocked instance for  <see cref="ListRowsActionMock"/> with static outputs.
        /// </summary>
        public ListRowsActionMock(TestWorkflowStatus status = TestWorkflowStatus.Succeeded, string name = null, ListRowsActionOutput outputs = null)
            : base(status: status, name: name, outputs: outputs ?? new ListRowsActionOutput())
        {
        }

        /// <summary>
        /// Creates a mocked instance for  <see cref="ListRowsActionMock"/> with static error info.
        /// </summary>
        public ListRowsActionMock(TestWorkflowStatus status, string name = null, TestErrorInfo error = null)
            : base(status: status, name: name, error: error)
        {
        }

        /// <summary>
        /// Creates a mocked instance for <see cref="ListRowsActionMock"/> with a callback function for dynamic outputs.
        /// </summary>
        public ListRowsActionMock(Func<TestExecutionContext, ListRowsActionMock> onGetActionMock, string name = null)
            : base(onGetActionMock: onGetActionMock, name: name)
        {
        }
    }


    /// <summary>
    /// Class for ListRowsActionOutput representing an object with properties.
    /// </summary>
    public class ListRowsActionOutput : MockOutput
    {
        /// <summary>
        /// List of tables
        /// </summary>
        public ListRowsActionOutputBody Body { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListRowsActionOutput"/> class.
        /// </summary>
        public ListRowsActionOutput()
        {
            this.StatusCode = HttpStatusCode.OK;
            this.Body = new ListRowsActionOutputBody();
        }

    }

    /// <summary>
    /// List of tables
    /// </summary>
    public class ListRowsActionOutputBody
    {
        /// <summary>
        /// List of Items
        /// </summary>
        public List<ListofItems> Value { get; set; }

        /// <summary>
        /// The url to fetch next page data.
        /// </summary>
        [JsonProperty(PropertyName="_odata.nextLink")]
        public string Nextlink { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListRowsActionOutputBody"/> class.
        /// </summary>
        public ListRowsActionOutputBody()
        {
            this.Value = new List<ListofItems>();
            this.Nextlink = string.Empty;
        }

    }

    /// <summary>
    /// [object Object]
    /// </summary>
    public class ListofItems
    {
        /// <summary>
        /// Type the company or business name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type the city for the primary address.
        /// </summary>
        public string Address1City { get; set; }

        /// <summary>
        /// Type the first line of the primary address.
        /// </summary>
        public string Address1Line1 { get; set; }

        /// <summary>
        /// Type the second line of the primary address.
        /// </summary>
        public string Address1Line2 { get; set; }

        /// <summary>
        /// Type the ZIP Code or postal code for the primary address.
        /// </summary>
        public string Address1Postalcode { get; set; }

        /// <summary>
        /// Type the annual revenue for the account, used as an indicator in financial performance analysis.
        /// </summary>
        public double Revenue { get; set; }

        /// <summary>
        /// Type the main phone number for this account.
        /// </summary>
        public string Telephone1 { get; set; }

        /// <summary>
        /// Type the number of employees that work at the account for use in marketing segmentation and demographic analysis.
        /// </summary>
        public int Numberofemployees { get; set; }

        /// <summary>
        /// OData row id
        /// </summary>
        [JsonProperty(PropertyName="_odata.id")]
        public string ODataId { get; set; }

        /// <summary>
        /// Choose the primary contact for the account to provide quick access to contact details.
        /// </summary>
        [JsonProperty(PropertyName="_primarycontactid_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string PrimaryContactType { get; set; }

        /// <summary>
        /// Choose the primary contact for the account to provide quick access to contact details.
        /// </summary>
        public string PrimarycontactidValue { get; set; }

        /// <summary>
        /// Shows the ID of the stage.
        /// </summary>
        public string Stageid { get; set; }

        /// <summary>
        /// For internal use only.
        /// </summary>
        public string Traversedpath { get; set; }

        /// <summary>
        /// Unique identifier of the account.
        /// </summary>
        public string Accountid { get; set; }

        /// <summary>
        /// Type an ID number or code for the account to quickly search and identify the account in system views.
        /// </summary>
        public string Accountnumber { get; set; }

        /// <summary>
        /// Select a rating to indicate the value of the customer account.
        /// </summary>
        public int Accountratingcode { get; set; }

        /// <summary>
        /// Shows the complete primary address.
        /// </summary>
        public string Address1Composite { get; set; }

        /// <summary>
        /// Select the primary address type.
        /// </summary>
        public int Address1Addresstypecode { get; set; }

        /// <summary>
        /// Type the country or region for the primary address.
        /// </summary>
        public string Address1Country { get; set; }

        /// <summary>
        /// Type the county for the primary address.
        /// </summary>
        public string Address1County { get; set; }

        /// <summary>
        /// Type the fax number associated with the primary address.
        /// </summary>
        public string Address1Fax { get; set; }

        /// <summary>
        /// Select the freight terms for the primary address to make sure shipping orders are processed correctly.
        /// </summary>
        public int Address1Freighttermscode { get; set; }

        /// <summary>
        /// Unique identifier for address 1.
        /// </summary>
        public string Address1Addressid { get; set; }

        /// <summary>
        /// Type the latitude value for the primary address for use in mapping and other applications.
        /// </summary>
        public double Address1Latitude { get; set; }

        /// <summary>
        /// Type the longitude value for the primary address for use in mapping and other applications.
        /// </summary>
        public double Address1Longitude { get; set; }

        /// <summary>
        /// Type a descriptive name for the primary address, such as Corporate Headquarters.
        /// </summary>
        public string Address1Name { get; set; }

        /// <summary>
        /// Type the post office box number of the primary address.
        /// </summary>
        public string Address1Postofficebox { get; set; }

        /// <summary>
        /// Type the name of the main contact at the account's primary address.
        /// </summary>
        public string Address1Primarycontactname { get; set; }

        /// <summary>
        /// Select a shipping method for deliveries sent to this address.
        /// </summary>
        public int Address1Shippingmethodcode { get; set; }

        /// <summary>
        /// Type the state or province of the primary address.
        /// </summary>
        public string Address1Stateorprovince { get; set; }

        /// <summary>
        /// Type the third line of the primary address.
        /// </summary>
        public string Address1Line3 { get; set; }

        /// <summary>
        /// Type a second phone number associated with the primary address.
        /// </summary>
        public string Address1Telephone2 { get; set; }

        /// <summary>
        /// Type a third phone number associated with the primary address.
        /// </summary>
        public string Address1Telephone3 { get; set; }

        /// <summary>
        /// Type the UPS zone of the primary address to make sure shipping charges are calculated correctly and deliveries are made promptly, if shipped by UPS.
        /// </summary>
        public string Address1Upszone { get; set; }

        /// <summary>
        /// Select the time zone, or UTC offset, for this address so that other people can reference it when they contact someone at this address.
        /// </summary>
        public int Address1Utcoffset { get; set; }

        /// <summary>
        /// Shows the complete secondary address.
        /// </summary>
        public string Address2Composite { get; set; }

        /// <summary>
        /// Select the secondary address type.
        /// </summary>
        public int Address2Addresstypecode { get; set; }

        /// <summary>
        /// Type the city for the secondary address.
        /// </summary>
        public string Address2City { get; set; }

        /// <summary>
        /// Type the country or region for the secondary address.
        /// </summary>
        public string Address2Country { get; set; }

        /// <summary>
        /// Type the county for the secondary address.
        /// </summary>
        public string Address2County { get; set; }

        /// <summary>
        /// Type the fax number associated with the secondary address.
        /// </summary>
        public string Address2Fax { get; set; }

        /// <summary>
        /// Select the freight terms for the secondary address to make sure shipping orders are processed correctly.
        /// </summary>
        public int Address2Freighttermscode { get; set; }

        /// <summary>
        /// Unique identifier for address 2.
        /// </summary>
        public string Address2Addressid { get; set; }

        /// <summary>
        /// Type the latitude value for the secondary address for use in mapping and other applications.
        /// </summary>
        public double Address2Latitude { get; set; }

        /// <summary>
        /// Type the longitude value for the secondary address for use in mapping and other applications.
        /// </summary>
        public double Address2Longitude { get; set; }

        /// <summary>
        /// Type a descriptive name for the secondary address, such as Corporate Headquarters.
        /// </summary>
        public string Address2Name { get; set; }

        /// <summary>
        /// Type the post office box number of the secondary address.
        /// </summary>
        public string Address2Postofficebox { get; set; }

        /// <summary>
        /// Type the name of the main contact at the account's secondary address.
        /// </summary>
        public string Address2Primarycontactname { get; set; }

        /// <summary>
        /// Select a shipping method for deliveries sent to this address.
        /// </summary>
        public int Address2Shippingmethodcode { get; set; }

        /// <summary>
        /// Type the state or province of the secondary address.
        /// </summary>
        public string Address2Stateorprovince { get; set; }

        /// <summary>
        /// Type the first line of the secondary address.
        /// </summary>
        public string Address2Line1 { get; set; }

        /// <summary>
        /// Type the second line of the secondary address.
        /// </summary>
        public string Address2Line2 { get; set; }

        /// <summary>
        /// Type the third line of the secondary address.
        /// </summary>
        public string Address2Line3 { get; set; }

        /// <summary>
        /// Type the main phone number associated with the secondary address.
        /// </summary>
        public string Address2Telephone1 { get; set; }

        /// <summary>
        /// Type a second phone number associated with the secondary address.
        /// </summary>
        public string Address2Telephone2 { get; set; }

        /// <summary>
        /// Type a third phone number associated with the secondary address.
        /// </summary>
        public string Address2Telephone3 { get; set; }

        /// <summary>
        /// Type the UPS zone of the secondary address to make sure shipping charges are calculated correctly and deliveries are made promptly, if shipped by UPS.
        /// </summary>
        public string Address2Upszone { get; set; }

        /// <summary>
        /// Select the time zone, or UTC offset, for this address so that other people can reference it when they contact someone at this address.
        /// </summary>
        public int Address2Utcoffset { get; set; }

        /// <summary>
        /// Type the ZIP Code or postal code for the secondary address.
        /// </summary>
        public string Address2Postalcode { get; set; }

        /// <summary>
        /// Type the main phone number associated with the primary address.
        /// </summary>
        public string Address1Telephone1 { get; set; }

        /// <summary>
        /// For system use only.
        /// </summary>
        public double Aging30 { get; set; }

        /// <summary>
        /// The base currency equivalent of the aging 30 field.
        /// </summary>
        public double Aging30Base { get; set; }

        /// <summary>
        /// For system use only.
        /// </summary>
        public double Aging60 { get; set; }

        /// <summary>
        /// The base currency equivalent of the aging 60 field.
        /// </summary>
        public double Aging60Base { get; set; }

        /// <summary>
        /// For system use only.
        /// </summary>
        public double Aging90 { get; set; }

        /// <summary>
        /// The base currency equivalent of the aging 90 field.
        /// </summary>
        public double Aging90Base { get; set; }

        /// <summary>
        /// Shows the annual revenue converted to the system's default base currency. The calculations use the exchange rate specified in the Currencies area.
        /// </summary>
        public double RevenueBase { get; set; }

        /// <summary>
        /// Select the legal designation or other business type of the account for contracts or reporting purposes.
        /// </summary>
        public int Businesstypecode { get; set; }

        /// <summary>
        /// Select a category to indicate whether the customer account is standard or preferred.
        /// </summary>
        public int Accountcategorycode { get; set; }

        /// <summary>
        /// Select a classification code to indicate the potential value of the customer account based on the projected return on investment, cooperation level, sales cycle length or other criteria.
        /// </summary>
        public int Accountclassificationcode { get; set; }

        /// <summary>
        /// Shows who created the record on behalf of another user.
        /// </summary>
        [JsonProperty(PropertyName="_createdonbehalfby_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string CreatedByDelegateType { get; set; }

        /// <summary>
        /// Shows who created the record on behalf of another user.
        /// </summary>
        public string CreatedonbehalfbyValue { get; set; }

        /// <summary>
        /// Shows the external party who created the record.
        /// </summary>
        [JsonProperty(PropertyName="_createdbyexternalparty_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string CreatedByExternalPartyType { get; set; }

        /// <summary>
        /// Shows the external party who created the record.
        /// </summary>
        public string CreatedbyexternalpartyValue { get; set; }

        public string AdxCreatedbyipaddress { get; set; }

        /// <summary>
        /// Shows who created the record.
        /// </summary>
        [JsonProperty(PropertyName="_createdby_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string CreatedByType { get; set; }

        public string AdxCreatedbyusername { get; set; }

        /// <summary>
        /// Shows who created the record.
        /// </summary>
        public string CreatedbyValue { get; set; }

        /// <summary>
        /// Shows the date and time when the record was created. The date and time are displayed in the time zone selected in Microsoft Dynamics 365 options.
        /// </summary>
        public DateTime Createdon { get; set; }

        /// <summary>
        /// Select whether the credit for the account is on hold. This is a useful reference while addressing the invoice and accounting issues with the customer.
        /// </summary>
        public bool Creditonhold { get; set; }

        /// <summary>
        /// Type the credit limit of the account. This is a useful reference when you address invoice and accounting issues with the customer.
        /// </summary>
        public double Creditlimit { get; set; }

        /// <summary>
        /// Shows the credit limit converted to the system's default base currency for reporting purposes.
        /// </summary>
        public double CreditlimitBase { get; set; }

        /// <summary>
        /// Choose the local currency for the record to make sure budgets are reported in the correct currency.
        /// </summary>
        [JsonProperty(PropertyName="_transactioncurrencyid_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string CurrencyType { get; set; }

        /// <summary>
        /// Choose the local currency for the record to make sure budgets are reported in the correct currency.
        /// </summary>
        public string TransactioncurrencyidValue { get; set; }

        /// <summary>
        /// Select the size category or range of the account for segmentation and reporting purposes.
        /// </summary>
        public int Customersizecode { get; set; }

        /// <summary>
        /// Shows the default image for the record.
        /// </summary>
        public string Entityimage { get; set; }

        /// <summary>
        /// Select whether the account allows bulk email sent through campaigns. If Do Not Allow is selected, the account can be added to marketing lists, but is excluded from email.
        /// </summary>
        public bool Donotbulkemail { get; set; }

        /// <summary>
        /// Select whether the account allows bulk postal mail sent through marketing campaigns or quick campaigns. If Do Not Allow is selected, the account can be added to marketing lists, but will be excluded from the postal mail.
        /// </summary>
        public bool Donotbulkpostalmail { get; set; }

        /// <summary>
        /// Select whether the account allows direct email sent from Microsoft Dynamics 365.
        /// </summary>
        public bool Donotemail { get; set; }

        /// <summary>
        /// Select whether the account allows faxes. If Do Not Allow is selected, the account will be excluded from fax activities distributed in marketing campaigns.
        /// </summary>
        public bool Donotfax { get; set; }

        /// <summary>
        /// Select whether the account allows direct mail. If Do Not Allow is selected, the account will be excluded from letter activities distributed in marketing campaigns.
        /// </summary>
        public bool Donotpostalmail { get; set; }

        /// <summary>
        /// Select whether the account allows phone calls. If Do Not Allow is selected, the account will be excluded from phone call activities distributed in marketing campaigns.
        /// </summary>
        public bool Donotphone { get; set; }

        /// <summary>
        /// Type the primary email address for the account.
        /// </summary>
        public string Emailaddress1 { get; set; }

        /// <summary>
        /// Type the secondary email address for the account.
        /// </summary>
        public string Emailaddress2 { get; set; }

        /// <summary>
        /// Type an alternate email address for the account.
        /// </summary>
        public string Emailaddress3 { get; set; }

        /// <summary>
        /// For internal use only.
        /// </summary>
        public string Entityimageid { get; set; }

        /// <summary>
        /// Shows the conversion rate of the record's currency. The exchange rate is used to convert all money fields in the record from the local currency to the system's default currency.
        /// </summary>
        public double Exchangerate { get; set; }

        /// <summary>
        /// Type the fax number for the account.
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Information about whether to allow following email activity like opens, attachment views and link clicks for emails sent to the account.
        /// </summary>
        public bool Followemail { get; set; }

        /// <summary>
        /// Type the URL for the account's FTP site to enable users to access data and share documents.
        /// </summary>
        public string Ftpsiteurl { get; set; }

        /// <summary>
        /// Unique identifier of the data import or data migration that created this record.
        /// </summary>
        public int Importsequencenumber { get; set; }

        /// <summary>
        /// Select the account's primary industry for use in marketing segmentation and demographic analysis.
        /// </summary>
        public int Industrycode { get; set; }

        /// <summary>
        /// Shows the date when the account was last included in a marketing campaign or quick campaign.1
        /// </summary>
        public DateTime Lastusedincampaign { get; set; }

        /// <summary>
        /// Contains the date and time stamp of the last on hold time.1
        /// </summary>
        public DateTime Lastonholdtime { get; set; }

        /// <summary>
        /// Last SLA that was applied to this case. This field is for internal use only.
        /// </summary>
        [JsonProperty(PropertyName="_slainvokedid_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string LastSLAappliedType { get; set; }

        /// <summary>
        /// Last SLA that was applied to this case. This field is for internal use only.
        /// </summary>
        public string SlainvokedidValue { get; set; }

        /// <summary>
        /// Unique identifier for Account associated with Account.
        /// </summary>
        [JsonProperty(PropertyName="_msa_managingpartnerid_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string ManagingPartnerType { get; set; }

        /// <summary>
        /// Unique identifier for Account associated with Account.
        /// </summary>
        public string MsaManagingpartneridValue { get; set; }

        /// <summary>
        /// Type the market capitalization of the account to identify the company's equity, used as an indicator in financial performance analysis.
        /// </summary>
        public double Marketcap { get; set; }

        /// <summary>
        /// Shows the market capitalization converted to the system's default base currency.
        /// </summary>
        public double MarketcapBase { get; set; }

        /// <summary>
        /// Whether is only for marketing
        /// </summary>
        public bool Marketingonly { get; set; }

        /// <summary>
        /// Shows the master account that the account was merged with.
        /// </summary>
        [JsonProperty(PropertyName="_masterid_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string MasterIDType { get; set; }

        /// <summary>
        /// Shows the master account that the account was merged with.
        /// </summary>
        public string MasteridValue { get; set; }

        /// <summary>
        /// Shows whether the account has been merged with another account.
        /// </summary>
        public bool Merged { get; set; }

        /// <summary>
        /// Shows who created the record on behalf of another user.
        /// </summary>
        [JsonProperty(PropertyName="_modifiedonbehalfby_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string ModifiedByDelegateType { get; set; }

        /// <summary>
        /// Shows who created the record on behalf of another user.
        /// </summary>
        public string ModifiedonbehalfbyValue { get; set; }

        /// <summary>
        /// Shows the external party who modified the record.
        /// </summary>
        [JsonProperty(PropertyName="_modifiedbyexternalparty_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string ModifiedByExternalPartyType { get; set; }

        /// <summary>
        /// Shows the external party who modified the record.
        /// </summary>
        public string ModifiedbyexternalpartyValue { get; set; }

        public string AdxModifiedbyipaddress { get; set; }

        /// <summary>
        /// Shows who last updated the record.
        /// </summary>
        [JsonProperty(PropertyName="_modifiedby_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string ModifiedByType { get; set; }

        public string AdxModifiedbyusername { get; set; }

        /// <summary>
        /// Shows who last updated the record.
        /// </summary>
        public string ModifiedbyValue { get; set; }

        /// <summary>
        /// Shows the date and time when the record was last updated. The date and time are displayed in the time zone selected in Microsoft Dynamics 365 options.
        /// </summary>
        public DateTime Modifiedon { get; set; }

        public int MsftDatastate { get; set; }

        /// <summary>
        /// Shows how long, in minutes, that the record was on hold.
        /// </summary>
        public int Onholdtime { get; set; }

        /// <summary>
        /// Type a second phone number for this account.
        /// </summary>
        public string Telephone2 { get; set; }

        /// <summary>
        /// Enter the user or team who is assigned to manage the record. This field is updated every time the record is assigned to a different user.
        /// </summary>
        [JsonProperty(PropertyName="_ownerid_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string OwnerType { get; set; }

        /// <summary>
        /// Enter the user or team who is assigned to manage the record. This field is updated every time the record is assigned to a different user.
        /// </summary>
        public string OwneridValue { get; set; }

        /// <summary>
        /// Select the account's ownership structure, such as public or private.
        /// </summary>
        public int Ownershipcode { get; set; }

        /// <summary>
        /// Shows the business unit that the record owner belongs to.
        /// </summary>
        [JsonProperty(PropertyName="_owningbusinessunit_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string OwningBusinessUnitType { get; set; }

        /// <summary>
        /// Shows the business unit that the record owner belongs to.
        /// </summary>
        public string OwningbusinessunitValue { get; set; }

        /// <summary>
        /// Unique identifier of the team who owns the account.
        /// </summary>
        [JsonProperty(PropertyName="_owningteam_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string OwningTeamType { get; set; }

        /// <summary>
        /// Unique identifier of the team who owns the account.
        /// </summary>
        public string OwningteamValue { get; set; }

        /// <summary>
        /// Unique identifier of the user who owns the account.
        /// </summary>
        [JsonProperty(PropertyName="_owninguser_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string OwningUserType { get; set; }

        /// <summary>
        /// Unique identifier of the user who owns the account.
        /// </summary>
        public string OwninguserValue { get; set; }

        /// <summary>
        /// Choose the parent account associated with this account to show parent and child businesses in reporting and analytics.
        /// </summary>
        [JsonProperty(PropertyName="_parentaccountid_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string ParentAccountType { get; set; }

        /// <summary>
        /// Choose the parent account associated with this account to show parent and child businesses in reporting and analytics.
        /// </summary>
        public string ParentaccountidValue { get; set; }

        /// <summary>
        /// For system use only. Legacy Microsoft Dynamics CRM 3.0 workflow data.
        /// </summary>
        public bool Participatesinworkflow { get; set; }

        /// <summary>
        /// Select the payment terms to indicate when the customer needs to pay the total amount.
        /// </summary>
        public int Paymenttermscode { get; set; }

        /// <summary>
        /// Select the preferred day of the week for service appointments.
        /// </summary>
        public int Preferredappointmentdaycode { get; set; }

        /// <summary>
        /// Select the preferred method of contact.
        /// </summary>
        public int Preferredcontactmethodcode { get; set; }

        /// <summary>
        /// Select the preferred time of day for service appointments.
        /// </summary>
        public int Preferredappointmenttimecode { get; set; }

        /// <summary>
        /// Choose the preferred service representative for reference when you schedule service activities for the account.
        /// </summary>
        [JsonProperty(PropertyName="_preferredsystemuserid_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string PreferredUserType { get; set; }

        /// <summary>
        /// Choose the preferred service representative for reference when you schedule service activities for the account.
        /// </summary>
        public string PreferredsystemuseridValue { get; set; }

        /// <summary>
        /// Primary Satori ID for Account
        /// </summary>
        public string Primarysatoriid { get; set; }

        /// <summary>
        /// Primary Twitter ID for Account
        /// </summary>
        public string Primarytwitterid { get; set; }

        /// <summary>
        /// Shows the ID of the process.
        /// </summary>
        public string Processid { get; set; }

        /// <summary>
        /// Date and time that the record was migrated.
        /// </summary>
        public DateTime Overriddencreatedon { get; set; }

        /// <summary>
        /// Select the category that best describes the relationship between the account and your organization.
        /// </summary>
        public int Customertypecode { get; set; }

        /// <summary>
        /// Select whether the account accepts marketing materials, such as brochures or catalogs.
        /// </summary>
        public bool Donotsendmm { get; set; }

        /// <summary>
        /// Type the number of shares available to the public for the account. This number is used as an indicator in financial performance analysis.
        /// </summary>
        public int Sharesoutstanding { get; set; }

        /// <summary>
        /// Select a shipping method for deliveries sent to the account's address to designate the preferred carrier or other delivery option.
        /// </summary>
        public int Shippingmethodcode { get; set; }

        /// <summary>
        /// Type the Standard Industrial Classification (SIC) code that indicates the account's primary industry of business, for use in marketing segmentation and demographic analysis.
        /// </summary>
        public string Sic { get; set; }

        /// <summary>
        /// Choose the service level agreement (SLA) that you want to apply to the Account record.
        /// </summary>
        [JsonProperty(PropertyName="_slaid_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string SLAType { get; set; }

        /// <summary>
        /// Choose the service level agreement (SLA) that you want to apply to the Account record.
        /// </summary>
        public string SlaidValue { get; set; }

        /// <summary>
        /// Shows whether the account is active or inactive. Inactive accounts are read-only and can't be edited unless they are reactivated.
        /// </summary>
        public int Statecode { get; set; }

        /// <summary>
        /// Select the account's status.
        /// </summary>
        public int Statuscode { get; set; }

        /// <summary>
        /// Type the stock exchange at which the account is listed to track their stock and financial performance of the company.
        /// </summary>
        public string Stockexchange { get; set; }

        /// <summary>
        /// Type a third phone number for this account.
        /// </summary>
        public string Telephone3 { get; set; }

        /// <summary>
        /// Select a region or territory for the account for use in segmentation and analysis.
        /// </summary>
        public int Territorycode { get; set; }

        /// <summary>
        /// Type the stock exchange symbol for the account to track financial performance of the company. You can click the code entered in this field to access the latest trading information from MSN Money.
        /// </summary>
        public string Tickersymbol { get; set; }

        /// <summary>
        /// Total time spent for emails (read and write) and meetings by me in relation to account record.
        /// </summary>
        public string Timespentbymeonemailandmeetings { get; set; }

        /// <summary>
        /// For internal use only.
        /// </summary>
        public int Timezoneruleversionnumber { get; set; }

        /// <summary>
        /// Time zone code that was in use when the record was created.
        /// </summary>
        public int Utcconversiontimezonecode { get; set; }

        public int Versionnumber { get; set; }

        /// <summary>
        /// Type the account's website URL to get quick details about the company profile.
        /// </summary>
        public string Websiteurl { get; set; }

        /// <summary>
        /// Type the phonetic spelling of the company name, if specified in Japanese, to make sure the name is pronounced correctly in phone calls and other communications.
        /// </summary>
        public string Yominame { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListofItems"/> class.
        /// </summary>
        public ListofItems()
        {
            this.Name = string.Empty;
            this.Address1City = string.Empty;
            this.Address1Line1 = string.Empty;
            this.Address1Line2 = string.Empty;
            this.Address1Postalcode = string.Empty;
            this.Telephone1 = string.Empty;
            this.Numberofemployees = 0;
            this.ODataId = string.Empty;
            this.PrimaryContactType = string.Empty;
            this.PrimarycontactidValue = string.Empty;
            this.Stageid = string.Empty;
            this.Traversedpath = string.Empty;
            this.Accountid = string.Empty;
            this.Accountnumber = string.Empty;
            this.Accountratingcode = 0;
            this.Address1Composite = string.Empty;
            this.Address1Addresstypecode = 0;
            this.Address1Country = string.Empty;
            this.Address1County = string.Empty;
            this.Address1Fax = string.Empty;
            this.Address1Freighttermscode = 0;
            this.Address1Addressid = string.Empty;
            this.Address1Name = string.Empty;
            this.Address1Postofficebox = string.Empty;
            this.Address1Primarycontactname = string.Empty;
            this.Address1Shippingmethodcode = 0;
            this.Address1Stateorprovince = string.Empty;
            this.Address1Line3 = string.Empty;
            this.Address1Telephone2 = string.Empty;
            this.Address1Telephone3 = string.Empty;
            this.Address1Upszone = string.Empty;
            this.Address1Utcoffset = 0;
            this.Address2Composite = string.Empty;
            this.Address2Addresstypecode = 0;
            this.Address2City = string.Empty;
            this.Address2Country = string.Empty;
            this.Address2County = string.Empty;
            this.Address2Fax = string.Empty;
            this.Address2Freighttermscode = 0;
            this.Address2Addressid = string.Empty;
            this.Address2Name = string.Empty;
            this.Address2Postofficebox = string.Empty;
            this.Address2Primarycontactname = string.Empty;
            this.Address2Shippingmethodcode = 0;
            this.Address2Stateorprovince = string.Empty;
            this.Address2Line1 = string.Empty;
            this.Address2Line2 = string.Empty;
            this.Address2Line3 = string.Empty;
            this.Address2Telephone1 = string.Empty;
            this.Address2Telephone2 = string.Empty;
            this.Address2Telephone3 = string.Empty;
            this.Address2Upszone = string.Empty;
            this.Address2Utcoffset = 0;
            this.Address2Postalcode = string.Empty;
            this.Address1Telephone1 = string.Empty;
            this.Businesstypecode = 0;
            this.Accountcategorycode = 0;
            this.Accountclassificationcode = 0;
            this.CreatedByDelegateType = string.Empty;
            this.CreatedonbehalfbyValue = string.Empty;
            this.CreatedByExternalPartyType = string.Empty;
            this.CreatedbyexternalpartyValue = string.Empty;
            this.AdxCreatedbyipaddress = string.Empty;
            this.CreatedByType = string.Empty;
            this.AdxCreatedbyusername = string.Empty;
            this.CreatedbyValue = string.Empty;
            this.Createdon = new DateTime();
            this.CurrencyType = string.Empty;
            this.TransactioncurrencyidValue = string.Empty;
            this.Customersizecode = 0;
            this.Entityimage = string.Empty;
            this.Emailaddress1 = string.Empty;
            this.Emailaddress2 = string.Empty;
            this.Emailaddress3 = string.Empty;
            this.Entityimageid = string.Empty;
            this.Fax = string.Empty;
            this.Ftpsiteurl = string.Empty;
            this.Importsequencenumber = 0;
            this.Industrycode = 0;
            this.Lastusedincampaign = new DateTime();
            this.Lastonholdtime = new DateTime();
            this.LastSLAappliedType = string.Empty;
            this.SlainvokedidValue = string.Empty;
            this.ManagingPartnerType = string.Empty;
            this.MsaManagingpartneridValue = string.Empty;
            this.MasterIDType = string.Empty;
            this.MasteridValue = string.Empty;
            this.ModifiedByDelegateType = string.Empty;
            this.ModifiedonbehalfbyValue = string.Empty;
            this.ModifiedByExternalPartyType = string.Empty;
            this.ModifiedbyexternalpartyValue = string.Empty;
            this.AdxModifiedbyipaddress = string.Empty;
            this.ModifiedByType = string.Empty;
            this.AdxModifiedbyusername = string.Empty;
            this.ModifiedbyValue = string.Empty;
            this.Modifiedon = new DateTime();
            this.MsftDatastate = 0;
            this.Onholdtime = 0;
            this.Telephone2 = string.Empty;
            this.OwnerType = string.Empty;
            this.OwneridValue = string.Empty;
            this.Ownershipcode = 0;
            this.OwningBusinessUnitType = string.Empty;
            this.OwningbusinessunitValue = string.Empty;
            this.OwningTeamType = string.Empty;
            this.OwningteamValue = string.Empty;
            this.OwningUserType = string.Empty;
            this.OwninguserValue = string.Empty;
            this.ParentAccountType = string.Empty;
            this.ParentaccountidValue = string.Empty;
            this.Paymenttermscode = 0;
            this.Preferredappointmentdaycode = 0;
            this.Preferredcontactmethodcode = 0;
            this.Preferredappointmenttimecode = 0;
            this.PreferredUserType = string.Empty;
            this.PreferredsystemuseridValue = string.Empty;
            this.Primarysatoriid = string.Empty;
            this.Primarytwitterid = string.Empty;
            this.Processid = string.Empty;
            this.Overriddencreatedon = new DateTime();
            this.Customertypecode = 0;
            this.Sharesoutstanding = 0;
            this.Shippingmethodcode = 0;
            this.Sic = string.Empty;
            this.SLAType = string.Empty;
            this.SlaidValue = string.Empty;
            this.Statecode = 0;
            this.Statuscode = 0;
            this.Stockexchange = string.Empty;
            this.Telephone3 = string.Empty;
            this.Territorycode = 0;
            this.Tickersymbol = string.Empty;
            this.Timespentbymeonemailandmeetings = string.Empty;
            this.Timezoneruleversionnumber = 0;
            this.Utcconversiontimezonecode = 0;
            this.Versionnumber = 0;
            this.Websiteurl = string.Empty;
            this.Yominame = string.Empty;
        }

    }

}