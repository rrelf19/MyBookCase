using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using MyBookCase.Module.BusinessObjects;

namespace MyBookCase.Module.Mobile.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class BarCodeScanController : ObjectViewController<DetailView, Book>
    {
        public const string EnabledInEditMode = "EnabledInEditMode"; //no idea
        private SimpleAction scanBarCodeAction; //

        public BarCodeScanController()
        {
            //
            scanBarCodeAction = new SimpleAction(this, "Scan", PredefinedCategory.Edit);
            scanBarCodeAction.ImageName = "Photo";
            scanBarCodeAction.RegisterClientScriptOnExecute("ScanScript", GetBarCodeClientScript());
            //

            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            scanBarCodeAction.Enabled[EnabledInEditMode] = View.ViewEditMode == DevExpress.ExpressApp.Editors.ViewEditMode.Edit;

            // Perform various tasks depending on the target View.
        }


        //
        protected string GetBarCodeClientScript()
        {
            return @"if (cordova && cordova.plugins && cordova.plugnins.barcodeScanner){
                    cordova.plugins.barcodeScanner.scan(
                        function (scanResult) {
                            if(!scanResult.cancelled) {
                                $model.CurrentObject.Isbn = scanResult.text; //!!!
                            }
                        }, 
                        function(scanError){
                            DevExpress.ui.notify({ closeOnClick: true, message: scanError, type: 'error' }, 'error, 5000);
                        }
                    );
                   }";
        }

        public SimpleAction ScanBarCodeAction
        {
            get { return scanBarCodeAction; }
        }
        //



        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
