class Phone extends React.Component {

    constructor(props) {
        super(props);
        this.state = { data: props.phone };
        this.onClick = this.onClick.bind(this);
    }
    onClick(e) {
        this.props.onRemove(this.state.data);
    }
    render() {
        return <div>
            
        </div>;
    }
}

class PhoneForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = { name: "", price: 0 };

        this.onSubmit = this.onSubmit.bind(this);
        this.onNameChange = this.onNameChange.bind(this);
        this.onPriceChange = this.onPriceChange.bind(this);
    }
    onNameChange(e) {
        this.setState({ name: e.target.value });
    }
    onPriceChange(e) {
        this.setState({ price: e.target.value });
    }
    onSubmit(e) {
        e.preventDefault();
        var phoneName = this.state.name.trim();
        var phonePrice = this.state.price;
        if (!phoneName || phonePrice <= 0) {
            return;
        }
        this.props.onPhoneSubmit({ name: phoneName, price: phonePrice });
        this.setState({ name: "", price: 0 });
    }
    render() {
        return (
            <div>
                <form onSubmit={this.onSubmit} >
                <label for="username">Username</label>
                <input  
                    value={this.state.name}
                    onChange={this.onNameChange}
                    type="text" id="username" name="username" required />

                    <label for="password">Password</label>
                    <input 
                        value={this.state.price}
                        onChange={this.onPriceChange}
                        type="password" id="password" name="password" required />

                <input type="submit" value="Login" onClick='location.href="homepage.html"' />
                
            </form>
               
            </div>
        );
    }
}


class PhonesList extends React.Component {

    constructor(props) {
        super(props);
        this.state = { phones: [] };

        this.onAddPhone = this.onAddPhone.bind(this);
        this.onRemovePhone = this.onRemovePhone.bind(this);
    }
    // �������� ������
    loadData() {
        var xhr = new XMLHttpRequest();
        xhr.open("get", this.props.apiUrl, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ phones: data });
        }.bind(this);
        xhr.send();
    }
    componentDidMount() {
        this.loadData();
    }
    // ���������� �������
    onAddPhone(phone) {
        if (phone) {

            const data = new FormData();
            data.append("name", phone.name);
            data.append("price", phone.price);
            var xhr = new XMLHttpRequest();

            xhr.open("post", this.props.apiUrl, true);
            xhr.onload = function () {
                if (xhr.status === 200) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send(data);
        }
    }
    // �������� �������
    onRemovePhone(phone) {

        if (phone) {
            var url = this.props.apiUrl + "/" + phone.id;

            var xhr = new XMLHttpRequest();
            xhr.open("delete", url, true);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.onload = function () {
                if (xhr.status === 200) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send();
        }
    }
    render() {

        var remove = this.onRemovePhone;
        return <div>
            <PhoneForm onPhoneSubmit={this.onAddPhone} />
            
            <div>
                
                {
                    this.state.phones.map(function (phone) {

                        return <Phone key={phone.id} phone={phone} onRemove={remove} />
                    })
                   
                }
            </div>
        </div>;
    }
}

ReactDOM.render(
    <PhonesList apiUrl="/api/phones" />,
    document.getElementById("s1s")
);