﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestClient.QService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Algorithm", Namespace="http://schemas.datacontract.org/2004/07/QProject")]
    [System.SerializableAttribute()]
    public partial class Algorithm : TestClient.QService.IDLessAlgorithm {
        
        private long idField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="IDLessAlgorithm", Namespace="http://schemas.datacontract.org/2004/07/QProject")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TestClient.QService.Algorithm))]
    public partial class IDLessAlgorithm : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string descriptionField;
        
        private string nameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.descriptionField, value) != true)) {
                    this.descriptionField = value;
                    this.RaisePropertyChanged("description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Plan", Namespace="http://schemas.datacontract.org/2004/07/QProject")]
    [System.SerializableAttribute()]
    public partial class Plan : TestClient.QService.IDLessPlan {
        
        private long idField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="IDLessPlan", Namespace="http://schemas.datacontract.org/2004/07/QProject")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TestClient.QService.Plan))]
    public partial class IDLessPlan : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private long algorithmField;
        
        private TestClient.QService.Dimension dimensionField;
        
        private TestClient.QService.Edge[] edgesField;
        
        private TestClient.QService.Vertice[] verticesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long algorithm {
            get {
                return this.algorithmField;
            }
            set {
                if ((this.algorithmField.Equals(value) != true)) {
                    this.algorithmField = value;
                    this.RaisePropertyChanged("algorithm");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public TestClient.QService.Dimension dimension {
            get {
                return this.dimensionField;
            }
            set {
                if ((object.ReferenceEquals(this.dimensionField, value) != true)) {
                    this.dimensionField = value;
                    this.RaisePropertyChanged("dimension");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public TestClient.QService.Edge[] edges {
            get {
                return this.edgesField;
            }
            set {
                if ((object.ReferenceEquals(this.edgesField, value) != true)) {
                    this.edgesField = value;
                    this.RaisePropertyChanged("edges");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public TestClient.QService.Vertice[] vertices {
            get {
                return this.verticesField;
            }
            set {
                if ((object.ReferenceEquals(this.verticesField, value) != true)) {
                    this.verticesField = value;
                    this.RaisePropertyChanged("vertices");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Dimension", Namespace="http://schemas.datacontract.org/2004/07/QProject")]
    [System.SerializableAttribute()]
    public partial class Dimension : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private long[] paramValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long[] paramValue {
            get {
                return this.paramValueField;
            }
            set {
                if ((object.ReferenceEquals(this.paramValueField, value) != true)) {
                    this.paramValueField = value;
                    this.RaisePropertyChanged("paramValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Edge", Namespace="http://schemas.datacontract.org/2004/07/QProject")]
    [System.SerializableAttribute()]
    public partial class Edge : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private long fromVField;
        
        private long toVField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long fromV {
            get {
                return this.fromVField;
            }
            set {
                if ((this.fromVField.Equals(value) != true)) {
                    this.fromVField = value;
                    this.RaisePropertyChanged("fromV");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long toV {
            get {
                return this.toVField;
            }
            set {
                if ((this.toVField.Equals(value) != true)) {
                    this.toVField = value;
                    this.RaisePropertyChanged("toV");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Vertice", Namespace="http://schemas.datacontract.org/2004/07/QProject")]
    [System.SerializableAttribute()]
    public partial class Vertice : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string contentField;
        
        private int levelField;
        
        private long numberField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string content {
            get {
                return this.contentField;
            }
            set {
                if ((object.ReferenceEquals(this.contentField, value) != true)) {
                    this.contentField = value;
                    this.RaisePropertyChanged("content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int level {
            get {
                return this.levelField;
            }
            set {
                if ((this.levelField.Equals(value) != true)) {
                    this.levelField = value;
                    this.RaisePropertyChanged("level");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long number {
            get {
                return this.numberField;
            }
            set {
                if ((this.numberField.Equals(value) != true)) {
                    this.numberField = value;
                    this.RaisePropertyChanged("number");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Range", Namespace="http://schemas.datacontract.org/2004/07/QProject")]
    [System.SerializableAttribute()]
    public partial class Range : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private long idField;
        
        private int[] lowerField;
        
        private int[] upperField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int[] lower {
            get {
                return this.lowerField;
            }
            set {
                if ((object.ReferenceEquals(this.lowerField, value) != true)) {
                    this.lowerField = value;
                    this.RaisePropertyChanged("lower");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int[] upper {
            get {
                return this.upperField;
            }
            set {
                if ((object.ReferenceEquals(this.upperField, value) != true)) {
                    this.upperField = value;
                    this.RaisePropertyChanged("upper");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="QService.IQServer")]
    public interface IQServer {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/GetAlgorithms", ReplyAction="http://tempuri.org/IQServer/GetAlgorithmsResponse")]
        TestClient.QService.Algorithm[] GetAlgorithms();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/GetAlgorithms", ReplyAction="http://tempuri.org/IQServer/GetAlgorithmsResponse")]
        System.Threading.Tasks.Task<TestClient.QService.Algorithm[]> GetAlgorithmsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/AddAlgorithm", ReplyAction="http://tempuri.org/IQServer/AddAlgorithmResponse")]
        long AddAlgorithm(TestClient.QService.IDLessAlgorithm alg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/AddAlgorithm", ReplyAction="http://tempuri.org/IQServer/AddAlgorithmResponse")]
        System.Threading.Tasks.Task<long> AddAlgorithmAsync(TestClient.QService.IDLessAlgorithm alg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/GetAlgorithm", ReplyAction="http://tempuri.org/IQServer/GetAlgorithmResponse")]
        TestClient.QService.Plan[] GetAlgorithm(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/GetAlgorithm", ReplyAction="http://tempuri.org/IQServer/GetAlgorithmResponse")]
        System.Threading.Tasks.Task<TestClient.QService.Plan[]> GetAlgorithmAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/SetAlgorithm", ReplyAction="http://tempuri.org/IQServer/SetAlgorithmResponse")]
        bool SetAlgorithm(string id, TestClient.QService.IDLessAlgorithm alg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/SetAlgorithm", ReplyAction="http://tempuri.org/IQServer/SetAlgorithmResponse")]
        System.Threading.Tasks.Task<bool> SetAlgorithmAsync(string id, TestClient.QService.IDLessAlgorithm alg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/DeleteAlgorithm", ReplyAction="http://tempuri.org/IQServer/DeleteAlgorithmResponse")]
        bool DeleteAlgorithm(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/DeleteAlgorithm", ReplyAction="http://tempuri.org/IQServer/DeleteAlgorithmResponse")]
        System.Threading.Tasks.Task<bool> DeleteAlgorithmAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/AddPlan", ReplyAction="http://tempuri.org/IQServer/AddPlanResponse")]
        bool AddPlan(TestClient.QService.IDLessPlan plan);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/AddPlan", ReplyAction="http://tempuri.org/IQServer/AddPlanResponse")]
        System.Threading.Tasks.Task<bool> AddPlanAsync(TestClient.QService.IDLessPlan plan);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/DeletePlan", ReplyAction="http://tempuri.org/IQServer/DeletePlanResponse")]
        bool DeletePlan(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/DeletePlan", ReplyAction="http://tempuri.org/IQServer/DeletePlanResponse")]
        System.Threading.Tasks.Task<bool> DeletePlanAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/GetPlansInRange", ReplyAction="http://tempuri.org/IQServer/GetPlansInRangeResponse")]
        TestClient.QService.Plan[] GetPlansInRange(TestClient.QService.Range range);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/GetPlansInRange", ReplyAction="http://tempuri.org/IQServer/GetPlansInRangeResponse")]
        System.Threading.Tasks.Task<TestClient.QService.Plan[]> GetPlansInRangeAsync(TestClient.QService.Range range);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/TestMethod", ReplyAction="http://tempuri.org/IQServer/TestMethodResponse")]
        string TestMethod();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQServer/TestMethod", ReplyAction="http://tempuri.org/IQServer/TestMethodResponse")]
        System.Threading.Tasks.Task<string> TestMethodAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IQServerChannel : TestClient.QService.IQServer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class QServerClient : System.ServiceModel.ClientBase<TestClient.QService.IQServer>, TestClient.QService.IQServer {
        
        public QServerClient() {
        }
        
        public QServerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public QServerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public QServerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public QServerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TestClient.QService.Algorithm[] GetAlgorithms() {
            return base.Channel.GetAlgorithms();
        }
        
        public System.Threading.Tasks.Task<TestClient.QService.Algorithm[]> GetAlgorithmsAsync() {
            return base.Channel.GetAlgorithmsAsync();
        }
        
        public long AddAlgorithm(TestClient.QService.IDLessAlgorithm alg) {
            return base.Channel.AddAlgorithm(alg);
        }
        
        public System.Threading.Tasks.Task<long> AddAlgorithmAsync(TestClient.QService.IDLessAlgorithm alg) {
            return base.Channel.AddAlgorithmAsync(alg);
        }
        
        public TestClient.QService.Plan[] GetAlgorithm(string id) {
            return base.Channel.GetAlgorithm(id);
        }
        
        public System.Threading.Tasks.Task<TestClient.QService.Plan[]> GetAlgorithmAsync(string id) {
            return base.Channel.GetAlgorithmAsync(id);
        }
        
        public bool SetAlgorithm(string id, TestClient.QService.IDLessAlgorithm alg) {
            return base.Channel.SetAlgorithm(id, alg);
        }
        
        public System.Threading.Tasks.Task<bool> SetAlgorithmAsync(string id, TestClient.QService.IDLessAlgorithm alg) {
            return base.Channel.SetAlgorithmAsync(id, alg);
        }
        
        public bool DeleteAlgorithm(string id) {
            return base.Channel.DeleteAlgorithm(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAlgorithmAsync(string id) {
            return base.Channel.DeleteAlgorithmAsync(id);
        }
        
        public bool AddPlan(TestClient.QService.IDLessPlan plan) {
            return base.Channel.AddPlan(plan);
        }
        
        public System.Threading.Tasks.Task<bool> AddPlanAsync(TestClient.QService.IDLessPlan plan) {
            return base.Channel.AddPlanAsync(plan);
        }
        
        public bool DeletePlan(string id) {
            return base.Channel.DeletePlan(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeletePlanAsync(string id) {
            return base.Channel.DeletePlanAsync(id);
        }
        
        public TestClient.QService.Plan[] GetPlansInRange(TestClient.QService.Range range) {
            return base.Channel.GetPlansInRange(range);
        }
        
        public System.Threading.Tasks.Task<TestClient.QService.Plan[]> GetPlansInRangeAsync(TestClient.QService.Range range) {
            return base.Channel.GetPlansInRangeAsync(range);
        }
        
        public string TestMethod() {
            return base.Channel.TestMethod();
        }
        
        public System.Threading.Tasks.Task<string> TestMethodAsync() {
            return base.Channel.TestMethodAsync();
        }
    }
}
