class HelloMessage extends React.Component {

    render() {
        return (
            <h1>Hello {this.props.name}</h1>
        )
    }
};

HelloMessage.defaultProps = {
    name: 'Runoob'
};

HelloMessage.propTypes = {
    name: React.PropTypes.string.isRequired
};

ReactDOM.render(
    <div>
        <HelloMessage />
        <HelloMessage name='Runoob' />
    </div>,
    document.getElementById('example')
)