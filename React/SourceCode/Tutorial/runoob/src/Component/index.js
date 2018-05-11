//import React from 'react';
//import ReactDOM from 'react-dom';
//import HelloMessage from './HelloWorld.js' 

var HelloMessage = React.createClass({
    render: function () {
        return <h1>Hello {this.props.name}！</h1>;
    }
});

class HelloWorld extends React.Component {
    render() {
        return (
            <h1>Hello {this.props.name}！</h1>
        )
    }
}

function HelloRunoob(props) {
    return (
        <h1>Hello {props.name}！</h1>
    )
}

class WebSite extends React.Component {
    render() {
        return (
            <div>
                <Name name={this.props.name} />
                <Link site={this.props.site} />
            </div>
        )
    }
}

class Name extends React.Component {
    render() {
        return (
            <h1>{this.props.name}</h1>
        )
    }
}

class Link extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            opacity: 1.0
        };
    }

    componentDidMount() {
        this.timer = setInterval(function () {
            var opacity = this.state.opacity;
            opacity -= 0.05;
            if (opacity < 0.1) opacity = 1.0;

            this.setState({
                opacity: opacity
            });
        }.bind(this), 100);
    }

    render() {
        return (
            <a href={this.props.site} style={{ opacity: this.state.opacity }}>{this.props.site}</a>
        )
    }
}

ReactDOM.render(
    <div>
        <h1>Hello, world!</h1>
        <HelloMessage name='Runoob' />
        <HelloWorld name='Runoob2' />
        <HelloRunoob name='Runoob3' />

        <WebSite name='复合组件' site='https://www.digitcyber.com' />
    </div>,
    document.getElementById('example')
);