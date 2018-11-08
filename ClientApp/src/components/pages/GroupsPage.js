import React from 'react';
import { connect } from 'react-redux'
import { paymentActions, alertActions } from '../../actions';

class GroupsPage extends React.Component {
    constructor(props) {
        super(props);
        const { payments, dispatch } = this.props;
        this.state = { payments, name: '', description: '', submitted: false };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        dispatch(paymentActions.getAllGroups())
    }

    handleChange(event) {
        const { name, value } = event.target;
        this.setState({ [name]: value });
    }

    handleSubmit(event) {
        event.preventDefault();
        this.setState({ submitted: true });
        const { name, description } = this.state;
        const { dispatch } = this.props;
        if (name && description) {
            dispatch(paymentActions.createGroup(name, description));
        } else if (!name) {
            dispatch(alertActions.error('Name cannot be empty'));
        }
    }

    render() {
        const { payments, name, description } = this.state;
        return (
            <div>
                <h3>pAYMENTS?</h3>
                <form name="form" onSubmit={this.handleSubmit}>
                    <div>
                        <label htmlFor="groupName">Name</label>
                        <input type="text" className="form-control" name="name" value={name} onChange={this.handleChange} />
                    </div>
                    <div>
                        <label htmlFor="groupDescription">Description</label>
                        <input type="text" className="form-control" name="description" value={description} onChange={this.handleChange} />
                    </div>
                    <button className="btn btn-primary">Add</button>
                </form>
                {payments.map((payment, i) => {
                    return <div key={`group_${i}`}>{payment.name}</div>
                })}
            </div>
        );
    }
}

const mapStateToProps = (state) => {
    const { payments, user } = state;
    return {
        payments,
        user
    };
}

const connectedGroupsPage = connect(mapStateToProps)(GroupsPage);
export { connectedGroupsPage as GroupsPage }; 