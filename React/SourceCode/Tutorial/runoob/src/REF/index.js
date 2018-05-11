class MyComponent extends React.Component {
    handleClick() {
        this.refs.myInput.focus();
        $(this.refs.myButton).val($(this.refs.myButton).val() + '1');
    }

    render() {
        return (
            <div>
                <input type='text' ref='myInput' />
                <input type='button' ref='myButton' value='点我输入框获取焦点'
                    onClick={() => this.handleClick()} />
            </div>
        )
    }
}

ReactDOM.render(
    <MyComponent />,
    document.getElementById('example')
);