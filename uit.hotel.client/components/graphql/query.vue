<template>
    <client-only>
        <apollo-query
            v-slot="{ result: { loading, error, data } }"
            :query="query"
            :variables="variables"
            :poll-interval="pollInterval"
            fetch-policy="no-cache"
            class="query"
            @result="$emit('result', $event)"
        >
            <div :class="childClass">
                <slot v-if="data" :data="data" />
                <div v-else class="query-text">
                    <span v-if="loading">
                        <icon- class="mr-1" i="loader" />
                        Đang tải dữ liệu...
                    </span>
                    <span v-else-if="error" class="text-red">
                        <icon- class="mr-1" i="alert-triangle" />
                        Đã có lỗi xảy ra!
                    </span>
                    <span v-else>
                        <icon- class="mr-1" i="loader" />
                        Đang yêu cầu dữ liệu...
                    </span>
                </div>
            </div>
        </apollo-query>
    </client-only>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'nuxt-property-decorator';

@Component({
    name: 'query-',
})
export default class extends Vue {
    @Prop({ required: true })
    query!: string;

    @Prop({ default: '' })
    childClass!: string;

    @Prop({ default: () => ({}) })
    variables!: object;

    @Prop({ default: 500 })
    pollInterval!: number;
}
</script>
<style lang="scss">
.query {
    > div > .query-text {
        display: flex;
        align-items: center;
        justify-content: center;
        height: 100%;
        margin: auto;
        padding: map-get($spacers, 3);
    }
    &.query-fill {
        display: flex;
        flex-basis: auto;
        flex-grow: 0;
        flex-shrink: 1;
        overflow: hidden;
        @include row-like;
        > div {
            flex: 1;
            margin: map-get($spacers, 2);
            overflow: auto;
            background-color: $white;
            border-radius: $border-radius;
            box-shadow: $box-shadow-sm;
            > div:not(.query-text) {
                min-width: fit-content;
                padding: map-get($spacers, 2);
            }
        }
    }
}
</style>
