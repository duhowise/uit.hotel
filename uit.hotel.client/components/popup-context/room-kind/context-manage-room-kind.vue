<template>
    <context- ref="context" v-slot="{ data: { roomKind } }">
        <b-nav-item-icon-
            icon="info"
            text="Xem thông tin chi tiết"
            @click="refs.room_kind_detail.open({ id: roomKind.id })"
        />
        <div class="context-hr" />
        <b-nav-item-icon-
            icon="receipt"
            text="Thêm giá cơ bản"
            @click="refs.price_add.open({ roomKind })"
        />
        <b-nav-item-icon-
            icon="receipt"
            text="Thêm giá biến động"
            @click="refs.price_volatility_add.open({ roomKind })"
        />
        <div class="context-hr" />
        <b-nav-item-icon-
            icon="edit-2"
            text="Sửa thông tin phòng"
            @click="refs.room_kind_update.open({ roomKind })"
        />
        <b-nav-item-icon-mutate-
            :mutation="setIsActiveRoomKind"
            :variables="{ id: roomKind.id, isActive: !roomKind.isActive }"
            :icon="roomKind.isActive ? 'x' : 'chevrons-up'"
            :text="
                roomKind.isActive
                    ? 'Vô hiệu hóa loại phòng'
                    : 'Kích hoạt lại loại phòng'
            "
        />
        <b-nav-item-icon-mutate-
            :mutation="deleteRoomKind"
            :variables="{ id: roomKind.id }"
            confirm
            icon="trash-2"
            text="Xóa loại phòng"
        />
    </context->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ContextMixin, DataMixin } from '~/components/mixins';
import { setIsActiveRoomKind, deleteRoomKind } from '~/graphql/documents';

@Component({
    name: 'context-manage-room-kind-',
})
export default class extends mixins<ContextMixin>(
    ContextMixin,
    DataMixin({ setIsActiveRoomKind, deleteRoomKind }),
) {}
</script>
