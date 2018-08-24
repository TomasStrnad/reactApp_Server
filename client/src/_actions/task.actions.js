import { userConstants } from '../_constants';
import { taskService } from '../_services';
import { alertActions } from './';
import { history } from '../_helpers';

export const taskActions = {
    getAll
};



function getAll() {

    //return null;
    return dispatch => {
        dispatch(request());

        taskService.getAll()
            .then(
                tasks => dispatch(success(tasks)),
                error => dispatch(failure(error))
            );
    };

    function request() { return { type: userConstants.GETALL_REQUEST } }
    function success(users) { return { type: userConstants.GETALL_SUCCESS, users } }
    function failure(error) { return { type: userConstants.GETALL_FAILURE, error } }
}
