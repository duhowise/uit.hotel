import {
    and,
    email,
    minLength,
    not,
    or,
    required,
} from 'vuelidate/lib/validators';
import { beforeDate, validDate } from './helper/dateValidator';

export const optionalEmail = {
    or: or(email, not(required)),
};

export const optionalBirthdate = {
    or: or(not(required), and(validDate, beforeDate())),
};

export const patronKindName = {
    required,
    minLength: minLength(3),
};

export const patronKindDescription = {
    required,
    minLength: minLength(3),
};
