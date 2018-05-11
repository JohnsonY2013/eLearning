// componentWillMount 
//      在渲染前调用,在客户端也在服务端。

// componentDidMount : 
//      在第一次渲染后调用，只在客户端。
//      之后组件已经生成了对应的DOM结构，可以通过this.getDOMNode()来进行访问。 
//      如果你想和其他JavaScript框架一起使用，可以在这个方法中调用setTimeout, setInterval或者发送AJAX请求等操作(防止异部操作阻塞UI)。

// componentWillReceiveProps 
//      在组件接收到一个新的 prop (更新后)时被调用。这个方法在初始化render时不会被调用。

// shouldComponentUpdate 
//      返回一个布尔值。在组件接收到新的props或者state时被调用。
//      在初始化时或者使用forceUpdate时不被调用。 
//      可以在你确认不需要更新组件时使用。

// componentWillUpdate
//      在组件接收到新的props或者state但还没有render时被调用。在初始化时不会被调用。

// componentDidUpdate 
//      在组件完成更新后立即调用。在初始化时不会被调用。

// componentWillUnmount
//      在组件从 DOM 中移除的时候立刻被调用。

class Content extends React.Component {

    componentWillReceiveProps(newProps) {
        console.log('Component WILL RECEIVE PROPS!');
    }

    render() {
        return (
            <div>
                <h3>{this.props.myNumber}</h3>
            </div>
        )
    }
}

class UserGist extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            username: '',
            lastGistUrl: ''
        };
    }

    componentDidMount() {
        console.log('2. Component DID MOUNT!');
        this.serverRequest = $.get(this.props.source, function (result) {
            var lastGist = result[0];
            this.setState({
                data: 0,
                username: lastGist.owner.login,
                lastGistUrl: lastGist.html_url
            });

        }.bind(this));
    }

    componentWillUnmount() {
        console.log('7. Component WILL UNMOUNT!');
        this.serverRequest.abort();
    }

    componentWillMount() {
        console.log('1. Component WILL MOUNT!');
    }

    componentWillReceiveProps(newProps) {
        console.log('X. Component WILL RECEIVE PROPS!');
    }

    shouldComponentUpdate(newProps, newState) {
        console.log('3. Component SHOULD UPDATE!');
        return true;
    }

    componentWillUpdate(newProps, newState) {
        console.log('4. Component WILL UPDATE!');
    }

    componentDidUpdate(prevProps, prevState) {
        console.log('5. Component DID UPDATE!');
    }

    setNewNumber() {
        this.setState({ data: this.state.data + 1 });
    }

    render() {
        return (
            <div>
                <button onClick={() => this.setNewNumber()}>INCREMENT</button>
                <Content myNumber={this.state.data} />
                {this.state.username} 用户最新的Gist共享地址：
                <a href={this.state.lastGistUrl}>{this.state.lastGistUrl}</a>
            </div>
        );
    }
}




ReactDOM.render(
    <UserGist source='https://api.github.com/users/octocat/gists' />,
    document.getElementById('example')
);