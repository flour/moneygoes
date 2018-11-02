import React from 'react';
import { connect } from 'react-redux'

const ProfilePage = ({ user }) => (
    <div>Profile?</div>
);

const mapStateToProps = (state) => {
    const { user } = state;
    return {
        user
    };
}

const connectedProfilePage = connect(mapStateToProps)(ProfilePage);
export { connectedProfilePage as ProfilePage }; 