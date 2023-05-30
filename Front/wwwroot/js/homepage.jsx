class UserModel extends React.Component {

    constructor(props) {
        super(props);
        this.state = { data: props.user };
        this.onClick = this.onClick.bind(this);
    }
    onClick(e) {
        this.props.onRemove(this.state.users);
    }
    render() {
        return <div>
           
            <div class="post-header">
                <h3>{this.state.data.name}</h3>
                <span>{this.state.data.email}</span>
            </div>
            <div class="post-content">
                <p>Interests</p>
                
            </div>
            <div class="post-footer">
                <ul>
                    <li><a href="#">View Profile</a></li>
                    <li><a href="#">Start conversation</a></li>
                    <li><a href="#">Share</a></li>
                </ul>
            </div>
        </div>;


    }
}

class UserForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = { name: "", email: "" };

        this.onSubmit = this.onSubmit.bind(this);
        this.onNameChange = this.onNameChange.bind(this);
        this.onEmailChange = this.onEmailChange.bind(this);
    }
    onNameChange(e) {
        this.setState({ name: e.target.value });
    }
    onEmailChange(e) {
        this.setState({ email: e.target.value });
    }
    onSubmit(e) {
        e.preventDefault();
        var userName = this.state.name.trim();
        var userEmail = "aa";
        if (!userName || !userEmail) {
            return;
        }
        this.props.onUserSubmit({ name: userName, email: userEmail });
        this.setState({ name: "", email: "" });
    }
    render() {
        return (

            <form class="search" onSubmit={this.onSubmit}>
                <input  
                    value={this.state.name}
                    onChange={this.onNameChange}
                    type="text" id="username" name="username" required />

                <input type="submit" value="Search..."  /> 
              
            </form>
        );
    }
}


class UsersList extends React.Component {

    constructor(props) {
        super(props);
        this.state = { users: [] };

        this.onAddUser = this.onAddUser.bind(this);
        this.onRemoveUser = this.onRemoveUser.bind(this);
    }
    // загрузка данных
    loadData() {
        var xhr = new XMLHttpRequest();
        xhr.open("get", this.props.apiUrl, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ users: data });
        }.bind(this);
        xhr.send();
    }
    componentDidMount() {
        this.loadData();
    }
    // добавление объекта
    onAddUser(user) {
        if (user) {

            const data = new FormData();
            data.append("name", user.name);
            data.append("email", user.email);
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
    // удаление объекта
    onRemoveUser(user) {

        if (user) {
            var url = this.props.apiUrl + "/" + user.name;

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

        var remove = this.onRemoveUser;
        return <div>
            <UserForm onUserSubmit={this.onAddUser} />
            <h2>List of users</h2>
            <div class="post">
                {
                    this.state.users.map(function (user) {

                        return <UserModel key={user.name} user={user} />
                    })
                }
            </div>
        </div>;
    }
}

ReactDOM.render(
    <UsersList apiUrl="/api/login" />,
    document.getElementById("s1s")
);