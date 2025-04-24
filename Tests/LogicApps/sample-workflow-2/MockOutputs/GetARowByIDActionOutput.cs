using Microsoft.Azure.Workflows.UnitTesting.Definitions;
using Microsoft.Azure.Workflows.UnitTesting.ErrorResponses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System;

namespace LogicApps.Tests.Mocks.sample_workflow_2
{
    /// <summary>
    /// The <see cref="GetARowByIDActionMock"/> class.
    /// </summary>
    public class GetARowByIDActionMock : ActionMock
    {
        /// <summary>
        /// Creates a mocked instance for  <see cref="GetARowByIDActionMock"/> with static outputs.
        /// </summary>
        public GetARowByIDActionMock(TestWorkflowStatus status = TestWorkflowStatus.Succeeded, string name = null, GetARowByIDActionOutput outputs = null)
            : base(status: status, name: name, outputs: outputs ?? new GetARowByIDActionOutput())
        {
        }

        /// <summary>
        /// Creates a mocked instance for  <see cref="GetARowByIDActionMock"/> with static error info.
        /// </summary>
        public GetARowByIDActionMock(TestWorkflowStatus status, string name = null, TestErrorInfo error = null)
            : base(status: status, name: name, error: error)
        {
        }

        /// <summary>
        /// Creates a mocked instance for <see cref="GetARowByIDActionMock"/> with a callback function for dynamic outputs.
        /// </summary>
        public GetARowByIDActionMock(Func<TestExecutionContext, GetARowByIDActionMock> onGetActionMock, string name = null)
            : base(onGetActionMock: onGetActionMock, name: name)
        {
        }
    }


    /// <summary>
    /// Class for GetARowByIDActionOutput representing an object with properties.
    /// </summary>
    public class GetARowByIDActionOutput : MockOutput
    {
        /// <summary>
        /// [object Object]
        /// </summary>
        public GetARowByIDActionOutputBody Body { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetARowByIDActionOutput"/> class.
        /// </summary>
        public GetARowByIDActionOutput()
        {
            this.StatusCode = HttpStatusCode.OK;
            this.Body = new GetARowByIDActionOutputBody();
        }

    }

    /// <summary>
    /// [object Object]
    /// </summary>
    public class GetARowByIDActionOutputBody
    {
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
        /// Type the main phone number for this contact.
        /// </summary>
        public string Telephone1 { get; set; }

        /// <summary>
        /// Select the parent account or parent contact for the contact to provide a quick link to additional details, such as financial information, activities, and opportunities.
        /// </summary>
        [JsonProperty(PropertyName="_parentcustomerid_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string CompanyNameType { get; set; }

        /// <summary>
        /// Select the parent account or parent contact for the contact to provide a quick link to additional details, such as financial information, activities, and opportunities.
        /// </summary>
        public string ParentcustomeridValue { get; set; }

        /// <summary>
        /// Type the primary email address for the contact.
        /// </summary>
        public string Emailaddress1 { get; set; }

        /// <summary>
        /// Type the contact's first name to make sure the contact is addressed correctly in sales calls, email, and marketing campaigns.
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Type the job title of the contact to make sure the contact is addressed correctly in sales calls, email, and marketing campaigns.
        /// </summary>
        public string Jobtitle { get; set; }

        /// <summary>
        /// Type the contact's last name to make sure the contact is addressed correctly in sales calls, email, and marketing campaigns.
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Type the mobile phone number for the contact.
        /// </summary>
        public string Mobilephone { get; set; }

        /// <summary>
        /// OData row id
        /// </summary>
        [JsonProperty(PropertyName="_odata.id")]
        public string ODataId { get; set; }

        /// <summary>
        /// Shows the ID of the stage.
        /// </summary>
        public string Stageid { get; set; }

        /// <summary>
        /// For internal use only.
        /// </summary>
        public string Traversedpath { get; set; }

        /// <summary>
        /// Shows the current count of failed password attempts for the contact.
        /// </summary>
        public int AdxIdentityAccessfailedcount { get; set; }

        /// <summary>
        /// Unique identifier of the account with which the contact is associated.
        /// </summary>
        [JsonProperty(PropertyName="_accountid_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string AccountType { get; set; }

        /// <summary>
        /// Unique identifier of the account with which the contact is associated.
        /// </summary>
        public string AccountidValue { get; set; }

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
        /// Type the main phone number associated with the primary address.
        /// </summary>
        public string Address1Telephone1 { get; set; }

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
        /// Shows the complete third address.
        /// </summary>
        public string Address3Composite { get; set; }

        /// <summary>
        /// Select the third address type.
        /// </summary>
        public int Address3Addresstypecode { get; set; }

        /// <summary>
        /// Type the city for the 3rd address.
        /// </summary>
        public string Address3City { get; set; }

        /// <summary>
        /// Type the county for the third address.
        /// </summary>
        public string Address3County { get; set; }

        /// <summary>
        /// Type the fax number associated with the third address.
        /// </summary>
        public string Address3Fax { get; set; }

        /// <summary>
        /// Select the freight terms for the third address to make sure shipping orders are processed correctly.
        /// </summary>
        public int Address3Freighttermscode { get; set; }

        /// <summary>
        /// Unique identifier for address 3.
        /// </summary>
        public string Address3Addressid { get; set; }

        /// <summary>
        /// Type the latitude value for the third address for use in mapping and other applications.
        /// </summary>
        public double Address3Latitude { get; set; }

        /// <summary>
        /// Type the longitude value for the third address for use in mapping and other applications.
        /// </summary>
        public double Address3Longitude { get; set; }

        /// <summary>
        /// Type a descriptive name for the third address, such as Corporate Headquarters.
        /// </summary>
        public string Address3Name { get; set; }

        /// <summary>
        /// the post office box number of the 3rd address.
        /// </summary>
        public string Address3Postofficebox { get; set; }

        /// <summary>
        /// Type the name of the main contact at the account's third address.
        /// </summary>
        public string Address3Primarycontactname { get; set; }

        /// <summary>
        /// Select a shipping method for deliveries sent to this address.
        /// </summary>
        public int Address3Shippingmethodcode { get; set; }

        /// <summary>
        /// Type the main phone number associated with the third address.
        /// </summary>
        public string Address3Telephone1 { get; set; }

        /// <summary>
        /// Type a second phone number associated with the third address.
        /// </summary>
        public string Address3Telephone2 { get; set; }

        /// <summary>
        /// Type a third phone number associated with the primary address.
        /// </summary>
        public string Address3Telephone3 { get; set; }

        /// <summary>
        /// Type the UPS zone of the third address to make sure shipping charges are calculated correctly and deliveries are made promptly, if shipped by UPS.
        /// </summary>
        public string Address3Upszone { get; set; }

        /// <summary>
        /// Select the time zone, or UTC offset, for this address so that other people can reference it when they contact someone at this address.
        /// </summary>
        public int Address3Utcoffset { get; set; }

        /// <summary>
        /// the country or region for the 3rd address.
        /// </summary>
        public string Address3Country { get; set; }

        /// <summary>
        /// the state or province of the third address.
        /// </summary>
        public string Address3Stateorprovince { get; set; }

        /// <summary>
        /// the first line of the 3rd address.
        /// </summary>
        public string Address3Line1 { get; set; }

        /// <summary>
        /// the second line of the 3rd address.
        /// </summary>
        public string Address3Line2 { get; set; }

        /// <summary>
        /// the third line of the 3rd address.
        /// </summary>
        public string Address3Line3 { get; set; }

        /// <summary>
        /// the ZIP Code or postal code for the 3rd address.
        /// </summary>
        public string Address3Postalcode { get; set; }

        /// <summary>
        /// For system use only.
        /// </summary>
        public double Aging30 { get; set; }

        /// <summary>
        /// Shows the Aging 30 field converted to the system's default base currency. The calculations use the exchange rate specified in the Currencies area.
        /// </summary>
        public double Aging30Base { get; set; }

        /// <summary>
        /// For system use only.
        /// </summary>
        public double Aging60 { get; set; }

        /// <summary>
        /// Shows the Aging 60 field converted to the system's default base currency. The calculations use the exchange rate specified in the Currencies area.
        /// </summary>
        public double Aging60Base { get; set; }

        /// <summary>
        /// For system use only.
        /// </summary>
        public double Aging90 { get; set; }

        /// <summary>
        /// Shows the Aging 90 field converted to the system's default base currency. The calculations use the exchange rate specified in the Currencies area.
        /// </summary>
        public double Aging90Base { get; set; }

        /// <summary>
        /// Enter the date of the contact's wedding or service anniversary for use in customer gift programs or other communications.
        /// </summary>
        public string Anniversary { get; set; }

        /// <summary>
        /// Type the contact's annual income for use in profiling and financial analysis.
        /// </summary>
        public double Annualincome { get; set; }

        /// <summary>
        /// Shows the Annual Income field converted to the system's default base currency. The calculations use the exchange rate specified in the Currencies area.
        /// </summary>
        public double AnnualincomeBase { get; set; }

        /// <summary>
        /// Type the name of the contact's assistant.
        /// </summary>
        public string Assistantname { get; set; }

        /// <summary>
        /// Type the phone number for the contact's assistant.
        /// </summary>
        public string Assistantphone { get; set; }

        /// <summary>
        /// Select whether the contact exists in a separate accounting or other system, such as Microsoft Dynamics GP or another ERP database, for use in integration processes.
        /// </summary>
        public bool Isbackofficecustomer { get; set; }

        /// <summary>
        /// Enter the contact's birthday for use in customer gift programs or other communications.
        /// </summary>
        public string Birthdate { get; set; }

        /// <summary>
        /// Type a second business phone number for this contact.
        /// </summary>
        public string Business2 { get; set; }

        /// <summary>
        /// Type a callback phone number for this contact.
        /// </summary>
        public string Callback { get; set; }

        /// <summary>
        /// Type the names of the contact's children for reference in communications and client programs.
        /// </summary>
        public string Childrensnames { get; set; }

        /// <summary>
        /// Type the company phone of the contact.
        /// </summary>
        public string Company { get; set; }

        public bool AdxConfirmremovepassword { get; set; }

        /// <summary>
        /// Unique identifier of the contact.
        /// </summary>
        public string Contactid { get; set; }

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

        /// <summary>
        /// Shows who created the record.
        /// </summary>
        [JsonProperty(PropertyName="_createdby_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string CreatedByType { get; set; }

        /// <summary>
        /// Shows who created the record.
        /// </summary>
        public string CreatedbyValue { get; set; }

        public string AdxCreatedbyipaddress { get; set; }

        public string AdxCreatedbyusername { get; set; }

        /// <summary>
        /// Shows the date and time when the record was created. The date and time are displayed in the time zone selected in Microsoft Dynamics 365 options.
        /// </summary>
        public DateTime Createdon { get; set; }

        /// <summary>
        /// Select whether the contact is on a credit hold, for reference when addressing invoice and accounting issues.
        /// </summary>
        public bool Creditonhold { get; set; }

        /// <summary>
        /// Type the credit limit of the contact for reference when you address invoice and accounting issues with the customer.
        /// </summary>
        public double Creditlimit { get; set; }

        /// <summary>
        /// Shows the Credit Limit field converted to the system's default base currency for reporting purposes. The calculations use the exchange rate specified in the Currencies area.
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
        /// Select the size of the contact's company for segmentation and reporting purposes.
        /// </summary>
        public int Customersizecode { get; set; }

        /// <summary>
        /// Type the department or business unit where the contact works in the parent company or business.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Indicates that the contact has opted out of web tracking.
        /// </summary>
        public bool MsdynDisablewebtracking { get; set; }

        /// <summary>
        /// Select whether the contact accepts bulk email sent through marketing campaigns or quick campaigns. If Do Not Allow is selected, the contact can be added to marketing lists, but will be excluded from the email.
        /// </summary>
        public bool Donotbulkemail { get; set; }

        /// <summary>
        /// Select whether the contact accepts bulk postal mail sent through marketing campaigns or quick campaigns. If Do Not Allow is selected, the contact can be added to marketing lists, but will be excluded from the letters.
        /// </summary>
        public bool Donotbulkpostalmail { get; set; }

        /// <summary>
        /// Select whether the contact allows direct email sent from Microsoft Dynamics 365. If Do Not Allow is selected, Microsoft Dynamics 365 will not send the email.
        /// </summary>
        public bool Donotemail { get; set; }

        /// <summary>
        /// Select whether the contact allows faxes. If Do Not Allow is selected, the contact will be excluded from any fax activities distributed in marketing campaigns.
        /// </summary>
        public bool Donotfax { get; set; }

        /// <summary>
        /// Select whether the contact allows direct mail. If Do Not Allow is selected, the contact will be excluded from letter activities distributed in marketing campaigns.
        /// </summary>
        public bool Donotpostalmail { get; set; }

        /// <summary>
        /// Select whether the contact accepts phone calls. If Do Not Allow is selected, the contact will be excluded from any phone call activities distributed in marketing campaigns.
        /// </summary>
        public bool Donotphone { get; set; }

        /// <summary>
        /// Select the contact's highest level of education for use in segmentation and analysis.
        /// </summary>
        public int Educationcode { get; set; }

        /// <summary>
        /// Type the secondary email address for the contact.
        /// </summary>
        public string Emailaddress2 { get; set; }

        /// <summary>
        /// Type an alternate email address for the contact.
        /// </summary>
        public string Emailaddress3 { get; set; }

        /// <summary>
        /// Determines if the email is confirmed by the contact.
        /// </summary>
        public bool AdxIdentityEmailaddress1confirmed { get; set; }

        /// <summary>
        /// Type the employee ID or number for the contact for reference in orders, service cases, or other communications with the contact's organization.
        /// </summary>
        public string Employeeid { get; set; }

        /// <summary>
        /// Shows the default image for the record.
        /// </summary>
        public string Entityimage { get; set; }

        /// <summary>
        /// For internal use only.
        /// </summary>
        public string Entityimageid { get; set; }

        /// <summary>
        /// Shows the conversion rate of the record's currency. The exchange rate is used to convert all money fields in the record from the local currency to the system's default currency.
        /// </summary>
        public double Exchangerate { get; set; }

        /// <summary>
        /// Identifier for an external user.
        /// </summary>
        public string Externaluseridentifier { get; set; }

        /// <summary>
        /// Type the fax number for the contact.
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Information about whether to allow following email activity like opens, attachment views and link clicks for emails sent to the contact.
        /// </summary>
        public bool Followemail { get; set; }

        /// <summary>
        /// Type the URL for the contact's FTP site to enable users to access data and share documents.
        /// </summary>
        public string Ftpsiteurl { get; set; }

        /// <summary>
        /// Combines and shows the contact's first and last names so that the full name can be displayed in views and reports.
        /// </summary>
        public string Fullname { get; set; }

        /// <summary>
        /// Select the contact's gender to make sure the contact is addressed correctly in sales calls, email, and marketing campaigns.
        /// </summary>
        public int Gendercode { get; set; }

        /// <summary>
        /// Type the passport number or other government ID for the contact for use in documents or reports.
        /// </summary>
        public string Governmentid { get; set; }

        /// <summary>
        /// Select whether the contact has any children for reference in follow-up phone calls and other communications.
        /// </summary>
        public int Haschildrencode { get; set; }

        /// <summary>
        /// Type a second phone number for this contact.
        /// </summary>
        public string Telephone2 { get; set; }

        /// <summary>
        /// Type a second home phone number for this contact.
        /// </summary>
        public string Home2 { get; set; }

        /// <summary>
        /// Unique identifier of the data import or data migration that created this record.
        /// </summary>
        public int Importsequencenumber { get; set; }

        /// <summary>
        /// Indicates that the contact is considered a minor in their jurisdiction.
        /// </summary>
        public bool MsdynIsminor { get; set; }

        /// <summary>
        /// Indicates that the contact is considered a minor in their jurisdiction and has parental consent.
        /// </summary>
        public bool MsdynIsminorwithparentalconsent { get; set; }

        /// <summary>
        /// Shows the date when the contact was last included in a marketing campaign or quick campaign.
        /// </summary>
        public DateTime Lastusedincampaign { get; set; }

        /// <summary>
        /// Contains the date and time stamp of the last on hold time.
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
        /// Indicates the last date and time the user successfully signed in to a portal.
        /// </summary>
        public DateTime AdxIdentityLastsuccessfullogin { get; set; }

        /// <summary>
        /// Select the primary marketing source that directed the contact to your organization.
        /// </summary>
        public int Leadsourcecode { get; set; }

        /// <summary>
        /// Indicates that the contact can no longer sign in to the portal using the local account.
        /// </summary>
        public bool AdxIdentityLocallogindisabled { get; set; }

        /// <summary>
        /// Determines if this contact will track failed access attempts and become locked after too many failed attempts. To prevent the contact from becoming locked, you can disable this setting.
        /// </summary>
        public bool AdxIdentityLockoutenabled { get; set; }

        /// <summary>
        /// Shows the moment in time when the locked contact becomes unlocked again.
        /// </summary>
        public DateTime AdxIdentityLockoutenddate { get; set; }

        /// <summary>
        /// Determines if web authentication is enabled for the contact.
        /// </summary>
        public bool AdxIdentityLogonenabled { get; set; }

        /// <summary>
        /// Type the name of the contact's manager for use in escalating issues or other follow-up communications with the contact.
        /// </summary>
        public string Managername { get; set; }

        /// <summary>
        /// Type the phone number for the contact's manager.
        /// </summary>
        public string Managerphone { get; set; }

        /// <summary>
        /// Unique identifier for Account associated with Contact.
        /// </summary>
        [JsonProperty(PropertyName="_msa_managingpartnerid_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string ManagingPartnerType { get; set; }

        /// <summary>
        /// Unique identifier for Account associated with Contact.
        /// </summary>
        public string MsaManagingpartneridValue { get; set; }

        /// <summary>
        /// Select the marital status of the contact for reference in follow-up phone calls and other communications.
        /// </summary>
        public int Familystatuscode { get; set; }

        /// <summary>
        /// Whether is only for marketing
        /// </summary>
        public bool Marketingonly { get; set; }

        /// <summary>
        /// Unique identifier of the master contact for merge.
        /// </summary>
        [JsonProperty(PropertyName="_masterid_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string MasterIDType { get; set; }

        /// <summary>
        /// Unique identifier of the master contact for merge.
        /// </summary>
        public string MasteridValue { get; set; }

        /// <summary>
        /// Shows whether the account has been merged with a master contact.
        /// </summary>
        public bool Merged { get; set; }

        /// <summary>
        /// Type the contact's middle name or initial to make sure the contact is addressed correctly.
        /// </summary>
        public string Middlename { get; set; }

        /// <summary>
        /// Determines if the phone number is confirmed by the contact.
        /// </summary>
        public bool AdxIdentityMobilephoneconfirmed { get; set; }

        /// <summary>
        /// Shows who last updated the record on behalf of another user.
        /// </summary>
        [JsonProperty(PropertyName="_modifiedonbehalfby_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string ModifiedByDelegateType { get; set; }

        /// <summary>
        /// Shows who last updated the record on behalf of another user.
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

        /// <summary>
        /// Shows who last updated the record.
        /// </summary>
        [JsonProperty(PropertyName="_modifiedby_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string ModifiedByType { get; set; }

        /// <summary>
        /// Shows who last updated the record.
        /// </summary>
        public string ModifiedbyValue { get; set; }

        public string AdxModifiedbyipaddress { get; set; }

        public string AdxModifiedbyusername { get; set; }

        /// <summary>
        /// Shows the date and time when the record was last updated. The date and time are displayed in the time zone selected in Microsoft Dynamics 365 options.
        /// </summary>
        public DateTime Modifiedon { get; set; }

        public int MsftDatastate { get; set; }

        public string AdxIdentityNewpassword { get; set; }

        /// <summary>
        /// Type the contact's nickname.
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Type the number of children the contact has for reference in follow-up phone calls and other communications.
        /// </summary>
        public int Numberofchildren { get; set; }

        /// <summary>
        /// Shows how long, in minutes, that the record was on hold.
        /// </summary>
        public int Onholdtime { get; set; }

        public string AdxOrganizationname { get; set; }

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
        /// Unique identifier of the business unit that owns the contact.
        /// </summary>
        [JsonProperty(PropertyName="_owningbusinessunit_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string OwningBusinessUnitType { get; set; }

        /// <summary>
        /// Unique identifier of the business unit that owns the contact.
        /// </summary>
        public string OwningbusinessunitValue { get; set; }

        /// <summary>
        /// Unique identifier of the team who owns the contact.
        /// </summary>
        [JsonProperty(PropertyName="_owningteam_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string OwningTeamType { get; set; }

        /// <summary>
        /// Unique identifier of the team who owns the contact.
        /// </summary>
        public string OwningteamValue { get; set; }

        /// <summary>
        /// Unique identifier of the user who owns the contact.
        /// </summary>
        [JsonProperty(PropertyName="_owninguser_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string OwningUserType { get; set; }

        /// <summary>
        /// Unique identifier of the user who owns the contact.
        /// </summary>
        public string OwninguserValue { get; set; }

        /// <summary>
        /// Type the pager number for the contact.
        /// </summary>
        public string Pager { get; set; }

        /// <summary>
        /// Unique identifier of the parent contact.
        /// </summary>
        [JsonProperty(PropertyName="_parentcontactid_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string ParentContactType { get; set; }

        /// <summary>
        /// Unique identifier of the parent contact.
        /// </summary>
        public string ParentcontactidValue { get; set; }

        /// <summary>
        /// Shows whether the contact participates in workflow rules.
        /// </summary>
        public bool Participatesinworkflow { get; set; }

        public string AdxIdentityPasswordhash { get; set; }

        /// <summary>
        /// Select the payment terms to indicate when the customer needs to pay the total amount.
        /// </summary>
        public int Paymenttermscode { get; set; }

        /// <summary>
        /// Indicates the date and time that the person agreed to the portal terms and conditions.
        /// </summary>
        public DateTime MsdynPortaltermsagreementdate { get; set; }

        /// <summary>
        /// Select the preferred day of the week for service appointments.
        /// </summary>
        public int Preferredappointmentdaycode { get; set; }

        /// <summary>
        /// User’s preferred portal language
        /// </summary>
        public int MsppUserpreferredlcid { get; set; }

        /// <summary>
        /// User’s preferred portal LCID
        /// </summary>
        public int AdxPreferredlcid { get; set; }

        /// <summary>
        /// Select the preferred method of contact.
        /// </summary>
        public int Preferredcontactmethodcode { get; set; }

        /// <summary>
        /// Select the preferred time of day for service appointments.
        /// </summary>
        public int Preferredappointmenttimecode { get; set; }

        /// <summary>
        /// Choose the regular or preferred customer service representative for reference when scheduling service activities for the contact.
        /// </summary>
        [JsonProperty(PropertyName="_preferredsystemuserid_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string PreferredUserType { get; set; }

        /// <summary>
        /// Choose the regular or preferred customer service representative for reference when scheduling service activities for the contact.
        /// </summary>
        public string PreferredsystemuseridValue { get; set; }

        /// <summary>
        /// Shows the ID of the process.
        /// </summary>
        public string Processid { get; set; }

        public bool AdxProfilealert { get; set; }

        public DateTime AdxProfilealertdate { get; set; }

        public string AdxProfilealertinstructions { get; set; }

        public bool AdxProfileisanonymous { get; set; }

        public DateTime AdxProfilelastactivity { get; set; }

        public DateTime AdxProfilemodifiedon { get; set; }

        public string AdxPublicprofilecopy { get; set; }

        /// <summary>
        /// Date and time that the record was migrated.
        /// </summary>
        public DateTime Overriddencreatedon { get; set; }

        /// <summary>
        /// Select the category that best describes the relationship between the contact and your organization.
        /// </summary>
        public int Customertypecode { get; set; }

        /// <summary>
        /// Select the contact's role within the company or sales process, such as decision maker, employee, or influencer.
        /// </summary>
        public int Accountrolecode { get; set; }

        /// <summary>
        /// Type the salutation of the contact to make sure the contact is addressed correctly in sales calls, email messages, and marketing campaigns.
        /// </summary>
        public string Salutation { get; set; }

        /// <summary>
        /// A token used to manage the web authentication session.
        /// </summary>
        public string AdxIdentitySecuritystamp { get; set; }

        /// <summary>
        /// Select whether the contact accepts marketing materials, such as brochures or catalogs. Contacts that opt out can be excluded from marketing initiatives.
        /// </summary>
        public bool Donotsendmm { get; set; }

        /// <summary>
        /// Select a shipping method for deliveries sent to this address.
        /// </summary>
        public int Shippingmethodcode { get; set; }

        /// <summary>
        /// Choose the service level agreement (SLA) that you want to apply to the Contact record.
        /// </summary>
        [JsonProperty(PropertyName="_slaid_value_Microsoft.Dynamics.CRM.lookuplogicalname")]
        public string SLAType { get; set; }

        /// <summary>
        /// Choose the service level agreement (SLA) that you want to apply to the Contact record.
        /// </summary>
        public string SlaidValue { get; set; }

        /// <summary>
        /// Type the name of the contact's spouse or partner for reference during calls, events, or other communications with the contact.
        /// </summary>
        public string Spousesname { get; set; }

        /// <summary>
        /// Shows whether the contact is active or inactive. Inactive contacts are read-only and can't be edited unless they are reactivated.
        /// </summary>
        public int Statecode { get; set; }

        /// <summary>
        /// Select the contact's status.
        /// </summary>
        public int Statuscode { get; set; }

        /// <summary>
        /// Type the suffix used in the contact's name, such as Jr. or Sr. to make sure the contact is addressed correctly in sales calls, email, and marketing campaigns.
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// Type a third phone number for this contact.
        /// </summary>
        public string Telephone3 { get; set; }

        /// <summary>
        /// Select a region or territory for the contact for use in segmentation and analysis.
        /// </summary>
        public int Territorycode { get; set; }

        /// <summary>
        /// Total time spent for emails (read and write) and meetings by me in relation to the contact record.
        /// </summary>
        public string Timespentbymeonemailandmeetings { get; set; }

        public int AdxTimezone { get; set; }

        /// <summary>
        /// For internal use only.
        /// </summary>
        public int Timezoneruleversionnumber { get; set; }

        /// <summary>
        /// Determines if two-factor authentication is enabled for the contact.
        /// </summary>
        public bool AdxIdentityTwofactorenabled { get; set; }

        /// <summary>
        /// Shows the user identity for local web authentication.
        /// </summary>
        public string AdxIdentityUsername { get; set; }

        /// <summary>
        /// Time zone code that was in use when the record was created.
        /// </summary>
        public int Utcconversiontimezonecode { get; set; }

        /// <summary>
        /// Version number of the contact.
        /// </summary>
        public int Versionnumber { get; set; }

        /// <summary>
        /// Type the contact's professional or personal website or blog URL.
        /// </summary>
        public string Websiteurl { get; set; }

        /// <summary>
        /// Type the phonetic spelling of the contact's first name, if the name is specified in Japanese, to make sure the name is pronounced correctly in phone calls with the contact.
        /// </summary>
        public string Yomifirstname { get; set; }

        /// <summary>
        /// Shows the combined Yomi first and last names of the contact so that the full phonetic name can be displayed in views and reports.
        /// </summary>
        public string Yomifullname { get; set; }

        /// <summary>
        /// Type the phonetic spelling of the contact's last name, if the name is specified in Japanese, to make sure the name is pronounced correctly in phone calls with the contact.
        /// </summary>
        public string Yomilastname { get; set; }

        /// <summary>
        /// Type the phonetic spelling of the contact's middle name, if the name is specified in Japanese, to make sure the name is pronounced correctly in phone calls with the contact.
        /// </summary>
        public string Yomimiddlename { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetARowByIDActionOutputBody"/> class.
        /// </summary>
        public GetARowByIDActionOutputBody()
        {
            this.Address1City = string.Empty;
            this.Address1Line1 = string.Empty;
            this.Address1Line2 = string.Empty;
            this.Address1Postalcode = string.Empty;
            this.Telephone1 = string.Empty;
            this.CompanyNameType = string.Empty;
            this.ParentcustomeridValue = string.Empty;
            this.Emailaddress1 = string.Empty;
            this.Firstname = string.Empty;
            this.Jobtitle = string.Empty;
            this.Lastname = string.Empty;
            this.Mobilephone = string.Empty;
            this.ODataId = string.Empty;
            this.Stageid = string.Empty;
            this.Traversedpath = string.Empty;
            this.AdxIdentityAccessfailedcount = 0;
            this.AccountType = string.Empty;
            this.AccountidValue = string.Empty;
            this.Address1Composite = string.Empty;
            this.Address1Addresstypecode = 0;
            this.Address1Country = string.Empty;
            this.Address1County = string.Empty;
            this.Address1Fax = string.Empty;
            this.Address1Freighttermscode = 0;
            this.Address1Addressid = string.Empty;
            this.Address1Name = string.Empty;
            this.Address1Telephone1 = string.Empty;
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
            this.Address3Composite = string.Empty;
            this.Address3Addresstypecode = 0;
            this.Address3City = string.Empty;
            this.Address3County = string.Empty;
            this.Address3Fax = string.Empty;
            this.Address3Freighttermscode = 0;
            this.Address3Addressid = string.Empty;
            this.Address3Name = string.Empty;
            this.Address3Postofficebox = string.Empty;
            this.Address3Primarycontactname = string.Empty;
            this.Address3Shippingmethodcode = 0;
            this.Address3Telephone1 = string.Empty;
            this.Address3Telephone2 = string.Empty;
            this.Address3Telephone3 = string.Empty;
            this.Address3Upszone = string.Empty;
            this.Address3Utcoffset = 0;
            this.Address3Country = string.Empty;
            this.Address3Stateorprovince = string.Empty;
            this.Address3Line1 = string.Empty;
            this.Address3Line2 = string.Empty;
            this.Address3Line3 = string.Empty;
            this.Address3Postalcode = string.Empty;
            this.Anniversary = string.Empty;
            this.Assistantname = string.Empty;
            this.Assistantphone = string.Empty;
            this.Birthdate = string.Empty;
            this.Business2 = string.Empty;
            this.Callback = string.Empty;
            this.Childrensnames = string.Empty;
            this.Company = string.Empty;
            this.Contactid = string.Empty;
            this.CreatedByDelegateType = string.Empty;
            this.CreatedonbehalfbyValue = string.Empty;
            this.CreatedByExternalPartyType = string.Empty;
            this.CreatedbyexternalpartyValue = string.Empty;
            this.CreatedByType = string.Empty;
            this.CreatedbyValue = string.Empty;
            this.AdxCreatedbyipaddress = string.Empty;
            this.AdxCreatedbyusername = string.Empty;
            this.Createdon = new DateTime();
            this.CurrencyType = string.Empty;
            this.TransactioncurrencyidValue = string.Empty;
            this.Customersizecode = 0;
            this.Department = string.Empty;
            this.Educationcode = 0;
            this.Emailaddress2 = string.Empty;
            this.Emailaddress3 = string.Empty;
            this.Employeeid = string.Empty;
            this.Entityimage = string.Empty;
            this.Entityimageid = string.Empty;
            this.Externaluseridentifier = string.Empty;
            this.Fax = string.Empty;
            this.Ftpsiteurl = string.Empty;
            this.Fullname = string.Empty;
            this.Gendercode = 0;
            this.Governmentid = string.Empty;
            this.Haschildrencode = 0;
            this.Telephone2 = string.Empty;
            this.Home2 = string.Empty;
            this.Importsequencenumber = 0;
            this.Lastusedincampaign = new DateTime();
            this.Lastonholdtime = new DateTime();
            this.LastSLAappliedType = string.Empty;
            this.SlainvokedidValue = string.Empty;
            this.AdxIdentityLastsuccessfullogin = new DateTime();
            this.Leadsourcecode = 0;
            this.AdxIdentityLockoutenddate = new DateTime();
            this.Managername = string.Empty;
            this.Managerphone = string.Empty;
            this.ManagingPartnerType = string.Empty;
            this.MsaManagingpartneridValue = string.Empty;
            this.Familystatuscode = 0;
            this.MasterIDType = string.Empty;
            this.MasteridValue = string.Empty;
            this.Middlename = string.Empty;
            this.ModifiedByDelegateType = string.Empty;
            this.ModifiedonbehalfbyValue = string.Empty;
            this.ModifiedByExternalPartyType = string.Empty;
            this.ModifiedbyexternalpartyValue = string.Empty;
            this.ModifiedByType = string.Empty;
            this.ModifiedbyValue = string.Empty;
            this.AdxModifiedbyipaddress = string.Empty;
            this.AdxModifiedbyusername = string.Empty;
            this.Modifiedon = new DateTime();
            this.MsftDatastate = 0;
            this.AdxIdentityNewpassword = string.Empty;
            this.Nickname = string.Empty;
            this.Numberofchildren = 0;
            this.Onholdtime = 0;
            this.AdxOrganizationname = string.Empty;
            this.OwnerType = string.Empty;
            this.OwneridValue = string.Empty;
            this.OwningBusinessUnitType = string.Empty;
            this.OwningbusinessunitValue = string.Empty;
            this.OwningTeamType = string.Empty;
            this.OwningteamValue = string.Empty;
            this.OwningUserType = string.Empty;
            this.OwninguserValue = string.Empty;
            this.Pager = string.Empty;
            this.ParentContactType = string.Empty;
            this.ParentcontactidValue = string.Empty;
            this.AdxIdentityPasswordhash = string.Empty;
            this.Paymenttermscode = 0;
            this.MsdynPortaltermsagreementdate = new DateTime();
            this.Preferredappointmentdaycode = 0;
            this.MsppUserpreferredlcid = 0;
            this.AdxPreferredlcid = 0;
            this.Preferredcontactmethodcode = 0;
            this.Preferredappointmenttimecode = 0;
            this.PreferredUserType = string.Empty;
            this.PreferredsystemuseridValue = string.Empty;
            this.Processid = string.Empty;
            this.AdxProfilealertdate = new DateTime();
            this.AdxProfilealertinstructions = string.Empty;
            this.AdxProfilelastactivity = new DateTime();
            this.AdxProfilemodifiedon = new DateTime();
            this.AdxPublicprofilecopy = string.Empty;
            this.Overriddencreatedon = new DateTime();
            this.Customertypecode = 0;
            this.Accountrolecode = 0;
            this.Salutation = string.Empty;
            this.AdxIdentitySecuritystamp = string.Empty;
            this.Shippingmethodcode = 0;
            this.SLAType = string.Empty;
            this.SlaidValue = string.Empty;
            this.Spousesname = string.Empty;
            this.Statecode = 0;
            this.Statuscode = 0;
            this.Suffix = string.Empty;
            this.Telephone3 = string.Empty;
            this.Territorycode = 0;
            this.Timespentbymeonemailandmeetings = string.Empty;
            this.AdxTimezone = 0;
            this.Timezoneruleversionnumber = 0;
            this.AdxIdentityUsername = string.Empty;
            this.Utcconversiontimezonecode = 0;
            this.Versionnumber = 0;
            this.Websiteurl = string.Empty;
            this.Yomifirstname = string.Empty;
            this.Yomifullname = string.Empty;
            this.Yomilastname = string.Empty;
            this.Yomimiddlename = string.Empty;
        }

    }

}