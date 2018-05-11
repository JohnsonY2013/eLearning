class HelloMessage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            value: 'Hello Runoob',
            manualValue: '',
        };
    }

    handleChange(event) {
        this.setState({ value: event.target.value });
    }

    assignValue(event) {
        this.setState({ manualValue: this.state.value.slice() });
    }

    render() {
        var value = this.state.value;
        return (
            <div>
                <input type='text' value={this.state.value} onChange={(event) => this.handleChange(event)} />
                {/* <input type='text' value={this.state.value} onChange={this.handleChange.bind(this)} /> */}
                <h4>{this.state.value}</h4>
                <br />
                <button onClick={(event) => this.assignValue(event)}>点我</button>
                <h4>{this.state.manualValue}</h4>
            </div>
        )
    }
}

class Content extends React.Component {
    render() {

        return (
            <div>
                <input type='text' value={this.props.myDataProp} onChange={this.props.updateStateProp} />
                <h4>{this.props.myDataProp}</h4>
                <br />
                <button onClick={this.props.assignStateProp}>点我</button>
                <h4>{this.props.myDataManualProp}</h4>
            </div>
        )
    }
};

class GreetMessage extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            value: 'Hello Runoob',
            manualValue: '',
        };
    }

    handleChange(event) {
        this.setState({ value: event.target.value });
    }

    assignValue(event) {
        this.setState({ manualValue: this.state.value.slice() });
    }

    render() {
        return (
            <div>
                <Content
                    myDataProp={this.state.value}
                    updateStateProp={(event) => this.handleChange(event)}
                    myDataManualProp={this.state.manualValue}
                    assignStateProp={(event) => this.assignValue(event)} />
            </div>
        )
    }
};

ReactDOM.render(
    <div>
        <HelloMessage />
        <hr />
        <GreetMessage />
    </div>,
    document.getElementById('example')
);