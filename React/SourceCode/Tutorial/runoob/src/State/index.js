
// ES6
class LinkButton extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            liked: false,
        }
    }

    handleClick() {
        this.setState({
            liked: !this.state.liked
        });
    }

    render() {

        return (
            <p onClick={() => this.handleClick()}>
                您<b>{this.state.liked ? '喜欢' : '不喜欢'}</b>我，点我切换
           </p>
        )

        // Alternative
        // return (
        //     <p onClick={this.handleClick.bind(this)}>
        //         您<b>{this.state.liked ? '喜欢' : '不喜欢'}</b>我，点我切换
        //    </p>
        // )

        // DOES NOT WORK
        // return (
        //     <p onClick={this.handleClick}>
        //         您<b>{this.state.liked ? '喜欢' : '不喜欢'}</b>我，点我切换
        //    </p>
        // )
    }
}

// ES5
var MyLinkButton = React.createClass({
    getInitialState: function () {
        return { liked: false };
    },
    handleClick: function (event) {
        this.setState({ liked: !this.state.liked });
    },
    render: function () {
        var text = this.state.liked ? '喜欢' : '不喜欢';
        return (
            <p onClick={this.handleClick}>
                你<b>{text}</b>我。点我切换状态。
          </p>
        );
    }
});

class Counter extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            clickCount: 0
        }
    }

    handleClick() {
        this.setState({
            clickCount: this.state.clickCount + 1
        });
    }

    render() {
        return (
            <h2 onClick={() => this.handleClick()}>点我！点击数为：{this.state.clickCount}</h2>
        )
    }
}


ReactDOM.render(
    <div>
        <LinkButton />
        <MyLinkButton />
        <Counter />
    </div>,
    document.getElementById('example')
)